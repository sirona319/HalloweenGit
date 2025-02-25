Shader "Pya/mosaicURP" {
    Properties {
        [Enum(UnityEngine.Rendering.CullMode)]
        _Cull("Cull", Float) = 0
        [KeywordEnum(mosaic1_normal, mosaic2_average, blur1_normal, blur2_gauss)] _Mode("Type", Float) = 0
        [Header(AspectRatio)]
        _AspectX("X", Float) = 16
        _AspectY("Y", Float) = 9
        [Space(7)]
        [Header(Mosaic)]
        _PixelationY("Pixelation Size", Range(1, 1000)) = 70
        [Space(7)]
        [Header(Blur)]
        _BlockSize("Block Size", Range(1, 1000)) = 10
        _SD("SD(blur2 only)", Range(1, 100)) = 10
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        ZWrite Off
        Cull [_Cull]

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _MODE_MOSAIC1_NORMAL _MODE_MOSAIC2_AVERAGE _MODE_BLUR1_NORMAL _MODE_BLUR2_GAUSS
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 grabPos : TEXCOORD0;
            };

            sampler2D _CameraColorTexture; // Use _CameraColorTexture instead of _OpaqueTexture
            float4 _CameraColorTexture_ST;
            float4 _CameraColorTexture_TexelSize;
            float _PixelationY;
            float _AspectX;
            float _AspectY;
            float _BlockSize;
            float _SD;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col;
                float2 uv = i.grabPos.xy / i.grabPos.w; // 0～1に変換
                float _PixelationX=_PixelationY*(_AspectX/_AspectY);//アスペクト比からモザイクのXのサイズ算出
                float2 uv_pixel = floor(uv * float2(_PixelationX, _PixelationY)) / float2(_PixelationX, _PixelationY); // ピクセル化

                #ifdef _MODE_MOSAIC1_NORMAL
                    col = tex2D(_CameraColorTexture, uv_pixel);
                #elif _MODE_MOSAIC2_AVERAGE
                    float count = 0;
                    for (int j = 0; j <= floor(1 / (_CameraColorTexture_TexelSize.x * _PixelationX)); j++) {
                        col = col + tex2D(_CameraColorTexture, uv_pixel + float2(j * _CameraColorTexture_TexelSize.x, 0));
                        count++;
                    }
                    col = col / count;
                #elif _MODE_BLUR1_NORMAL
                    float count = 0;
                    float size = floor(_BlockSize) * 0.1;
                    for (int j = -size; j <= size; j++) {
                        col = col + tex2D(_CameraColorTexture, uv + float2(j * _CameraColorTexture_TexelSize.x, 0));
                        count++;
                    }
                    col = col / count;
                #elif _MODE_BLUR2_GAUSS
                    float size = floor(_BlockSize) * 0.1;
                    float weight_total;
                    float var = pow(_SD, 2) * 0.001; // 分散

                    for (int j = -size; j <= size; j++) {
                        float distance = j / size;
                        float weight = exp(-0.5 * pow(distance, 2) / var);
                        weight_total = weight_total + weight;
                        col = col + tex2D(_CameraColorTexture, uv + float2(j * _CameraColorTexture_TexelSize.x, 0)) * weight;
                    }
                    col = col / weight_total;
                #endif

                return col;
            }
            ENDCG
        }

        // Y方向へのぼかし処理
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _MODE_MOSAIC1_NORMAL _MODE_MOSAIC2_AVERAGE _MODE_BLUR1_NORMAL _MODE_BLUR2_GAUSS
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 grabPos : TEXCOORD0;
            };

            sampler2D _CameraColorTexture; // Use _CameraColorTexture instead of _OpaqueTexture
            float4 _CameraColorTexture_ST;
            float4 _CameraColorTexture_TexelSize;
            float _BlockSize;
            float _SD;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col;
                float2 uv = i.grabPos.xy / i.grabPos.w; // 0～1に変換

                #ifdef _MODE_MOSAIC1_NORMAL
                    // 何もしない
                    col = tex2D(_CameraColorTexture, uv);
                #elif _MODE_MOSAIC2_AVERAGE
                    // 何もしない
                    col = tex2D(_CameraColorTexture, uv);
                #elif _MODE_BLUR1_NORMAL
                    float count = 0;
                    float size = floor(_BlockSize) * 0.1;
                    for (int j = -size; j <= size; j++) {
                        col = col + tex2D(_CameraColorTexture, uv + float2(0, j * abs(_CameraColorTexture_TexelSize.y)));
                        count++;
                    }
                    col = col / count;
                #elif _MODE_BLUR2_GAUSS
                    float size = floor(_BlockSize) * 0.1;
                    float weight_total;
                    float var = pow(_SD, 2) * 0.001;

                    for (int j = -size; j <= size; j++) {
                        float distance = j / size;
                        float weight = exp(-0.5 * pow(distance, 2) / var);
                        weight_total = weight_total + weight;
                        col = col + tex2D(_CameraColorTexture, uv + float2(0, j * abs(_CameraColorTexture_TexelSize.y))) * weight;
                    }
                    col = col / weight_total;
                #endif

                return col;
            }
            ENDCG
        }
    }
}

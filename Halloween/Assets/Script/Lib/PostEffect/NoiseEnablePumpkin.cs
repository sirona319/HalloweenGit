using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//ワープ攻撃用に　移行する？　汎用化

public class NoiseEnablePumpkin : MonoBehaviour
{

    //ノイズ　瞬間移動
    //public bool isNoise;
    public float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる
    float noiseLength = 0.5f;
    float noiseTime = 0f;

    GameObject[] warpPositions;
    float randTime = 0f;
    float randTimeMax = 2f;
    float randTimeMin = 0.5f;

    //赤かぼちゃのみ
    const float noiseTimingDefaultRed = 8f;
    //
    Transform pTrans;

    void Start()
    {

        //stateController.Initialize((int)FlyCtr.State.Fly_Wait);

        randTime = Random.Range(randTimeMin, randTimeMax);
        pTrans = GameObject.FindWithTag(TagName.Player).transform;

        warpPositions = GameObject.FindGameObjectsWithTag("PumpkinWorp");

    }

    /// <summary>
    /// カメラに写っている間常に呼ばれる SpriteRendererの関係で不具合が起こる**
    /// </summary>
    private void OnWillRenderObject()
    {
        //if (!isNoise) return;
        if (noiseTime >= (noiseTiming + randTime) + noiseLength) return;

        noiseTime += Time.deltaTime;


        if (noiseTime > noiseTiming + randTime && GetComponent<NoiseEnable>().enabled == false)
        {
            WorpPositionSelect();

            //ノイズを有効に
            GetComponent<NoiseEnable>().enabled = true;

        }

        if (noiseTime >= (noiseTiming + randTime) + noiseLength && GetComponent<NoiseEnable>().enabled == true)
        {

            //赤かぼちゃのみ
            if (transform.name.Contains("Red"))
            {
                //乱数の再計算　大きめにする？
                //タイミングの加算
                randTime = Random.Range(randTimeMin, randTimeMax + 1);

                noiseTiming += noiseTimingDefaultRed;
            }

            GetComponent<NoiseEnable>().enabled = false;

        }


#if UNITY_EDITOR

        //if (Camera.current.name != "Main Camera" && Camera.current.name != "Preview Camera")
        //Debug.Log("OnWillRenderOject");
        //Camera.current.transform;
#endif
    }



    void WorpPositionSelect()
    {
        //const float speed = 12f;
        List<Vector2> warpList = new ();

        //var points = GameObject.FindGameObjectsWithTag("PumpkinWorp");
        foreach (var i in warpPositions)
        {
            warpList.Add(i.transform.position);
        }

        while (true)
        {

            //ランダムで座標を決定
            var randInt = Random.Range(0, warpList.Count);

            //座標移動させる　カメラ内かどうか判定
            if (MyLib.IsVisibleByCamera(warpList[randInt]))
            {
                if (transform.name.Contains("Red"))
                {
                    var sMove = GetComponent<StraightForceMove>();
                    //sMove.rb2.position = warpList[randInt];
                    var dir = (Vector2)pTrans.position - (Vector2)warpList[randInt];

                    //sMove.rb2.linearVelocity = dir.normalized * speed;
                }
                else
                {
                    var sMove = GetComponent<SPointMovePumpkin>();
                    sMove.transform.position = warpList[randInt];
                    var dir = (Vector2)pTrans.position - (Vector2)warpList[randInt];

                    sMove.ReTarget(pTrans);
                    //sMove.transform.linearVelocity = dir.normalized * speed;
                }


                Debug.Log("ワープ");
                break;
            }
            else
            {
                warpList.RemoveAt(randInt);
                Debug.Log("ワープに失敗");
                //return false;
            }
        }
    }
}


//    /// <summary>
//    /// Rendererが任意のカメラから見えると呼び出される
//    /// </summary>
//    private void OnBecameVisible()
//    {
//        //GetComponent<NoiseEnable>().enabled = true;

//        //idRend = true;
//        //Debug.Log("OnBecameVisible");
//        //this.GetComponent<Renderer>().material.color = Color.red;
//    }

//    /// <summary>
//    /// Rendererがカメラから見えなくなると呼び出される
//    /// </summary>
//    private void OnBecameInvisible()
//    {
//        //GetComponent<NoiseEnable>().enabled = false;

//        //Debug.Log("OnBecameInvisible");
//        //this.GetComponent<Renderer>().material.color = Color.blue;
//    }
//}

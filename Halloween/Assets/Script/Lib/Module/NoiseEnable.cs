using UnityEngine;

public class NoiseEnable : MonoBehaviour
{
    Material defaultMat;
    [SerializeField] Material m;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] float blocksize;
    [SerializeField] float amount;
    [SerializeField] float frequency;
    [SerializeField] float duration;

    private void OnEnable()
    {
        
        defaultMat = spriteR.material;
        spriteR.material= m;
        //値の変更には_が必須
        spriteR.material.SetFloat("_BlockSize", blocksize);
        spriteR.material.SetFloat("_GlitchAmount", amount);
        spriteR.material.SetFloat("_GlitchFrequency", frequency);
        spriteR.material.SetFloat("_GlitchDuration", duration);

    }

    private void OnDisable()
    {

        spriteR.material = defaultMat;

    }
}

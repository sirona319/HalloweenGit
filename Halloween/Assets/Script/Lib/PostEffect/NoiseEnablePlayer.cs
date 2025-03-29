using UnityEngine;

public class NoiseEnablePlayer : MonoBehaviour
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
        spriteR.material = m;
        //値の変更には_が必須
        spriteR.material.SetFloat("_BlockSize", blocksize);
        spriteR.material.SetFloat("_GlitchAmount", amount);
        spriteR.material.SetFloat("_GlitchFrequency", frequency);
        spriteR.material.SetFloat("_GlitchDuration", duration);
        GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<PlayerMove>().isNoise = true;
    }

    //private void FixedUpdate()
    //{
    //    if (GetComponent<PlayerMove>().isNoise)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = false;
    //    }
    //}

    private void OnDisable()
    {

        spriteR.material = defaultMat;
        GetComponent<PlayerMove>().isNoise = false;
    }
}

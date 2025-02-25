using UnityEngine;

public class FadeModule : MonoBehaviour
{

    [SerializeField] bool fadeIn = false;
    [SerializeField] bool fadeOut = true;

    [SerializeField] float fadeSpeed = 0.06f;
    float alpha = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(fadeIn)
        {
            alpha = GetComponent<SpriteRenderer>().material.color.a;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutMode();

        if(fadeIn)
        {

        }

    }

    void FadeOutMode()
    {
        if (!fadeOut) return;

        alpha -= fadeSpeed;//Time.deltaTime;
        if (alpha <= 0)
            alpha = 0;


        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alpha);

    }
}

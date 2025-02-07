using System;
using UnityEngine;

public class EnableControl : MonoBehaviour
{
    public bool startEnable;
    public bool isSprite;
    public bool isBox2Col;
    public bool isBox3Col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isSprite)
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        if(isBox2Col)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (isBox3Col)
            gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using UnityEngine;

public class EnableControl : MonoBehaviour
{
    public bool startEnable;
    public bool isSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isSprite)
        gameObject.GetComponent<SpriteRenderer>().enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

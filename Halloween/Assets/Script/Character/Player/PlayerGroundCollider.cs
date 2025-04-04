﻿using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{

    PlayerMove pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Ground)||
            collision.gameObject.CompareTag(TagName.GroundRight)
            ||collision.gameObject.CompareTag(TagName.GroundBreak))
        {
            pScr.IsGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pScr.IsGround) return;

        if (collision.gameObject.CompareTag(TagName.Ground)||
            collision.gameObject.CompareTag(TagName.GroundRight)
                        || collision.gameObject.CompareTag(TagName.GroundBreak))
        {
            pScr.IsGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Ground)
            || collision.gameObject.CompareTag(TagName.GroundRight)
                        || collision.gameObject.CompareTag(TagName.GroundBreak))
        {

            pScr.IsGround = false;
            //Debug.Log("GROUND FALSE");
        }
    }
}

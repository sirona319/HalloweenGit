using UnityEngine;

public class PlayerGroundColliderTop : MonoBehaviour
{
    PlayerMove pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Ground)
                        || collision.gameObject.CompareTag(TagName.GroundBreak))
        {
            if (pScr.isJump)
                pScr.isJump = false;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Ground)
                        || collision.gameObject.CompareTag(TagName.GroundBreak))

        {
            if (pScr.isJump)
                pScr.isJump = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pScr.IsGround) return;

        if (collision.gameObject.CompareTag(TagName.Ground)
                        || collision.gameObject.CompareTag(TagName.GroundBreak))
        {

            if (pScr.isJump)
                pScr.isJump = false;
            //Debug.Log("GROUND TRUE");
        }
    }
}

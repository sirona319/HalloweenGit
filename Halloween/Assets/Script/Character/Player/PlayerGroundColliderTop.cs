using UnityEngine;

public class PlayerGroundColliderTop : MonoBehaviour
{
    PlayerScr2D pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerScr2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (pScr.isJump)
                pScr.isJump = false;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (pScr.isJump)
                pScr.isJump = false;
        }

    }
}

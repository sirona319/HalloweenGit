using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
    PlayerScr2D pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerScr2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            pScr.isGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pScr.isGround) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            pScr.isGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            pScr.isGround = false;
            //Debug.Log("GROUND FALSE");
        }
    }
}

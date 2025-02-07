using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent.GetComponent<PlayerScr2D>().isGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.parent.GetComponent<PlayerScr2D>().isGround) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent.GetComponent<PlayerScr2D>().isGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            transform.parent.GetComponent<PlayerScr2D>().isGround = false;
            //Debug.Log("GROUND FALSE");
        }
    }
}

using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
    PlayerMove pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Ground))
        {
            pScr.IsGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pScr.IsGround) return;

        if (collision.gameObject.CompareTag(TagName.Ground))
        {
            pScr.IsGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Ground))
        {

            pScr.IsGround = false;
            //Debug.Log("GROUND FALSE");
        }
    }
}

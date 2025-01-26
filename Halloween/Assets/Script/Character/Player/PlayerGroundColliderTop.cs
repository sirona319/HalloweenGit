using UnityEngine;

public class PlayerGroundColliderTop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (transform.parent.GetComponent<PlayerScr2D>().isJump)
                transform.parent.GetComponent<PlayerScr2D>().isJump = false;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (transform.parent.GetComponent<PlayerScr2D>().isJump)
                transform.parent.GetComponent<PlayerScr2D>().isJump = false;
        }

    }
}

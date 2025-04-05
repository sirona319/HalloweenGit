using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
    public MoveFloor2D moveObj;
    PlayerMove pScr;
    void Start()
    {
        pScr = transform.parent.GetComponent<PlayerMove>();
    }

    private void Update()
    {
        //移動速度を設定
        //Vector2 addVelocity = Vector2.zero;
        //if (moveObj != null)
        //{
        //    addVelocity = moveObj.GetVelocity();


        //}
        ////各種座標軸の速度を求める
        //float xSpeed = transform.parent.GetComponent<Rigidbody2D>().linearVelocityX;
        //float ySpeed = transform.parent.GetComponent<Rigidbody2D>().linearVelocityY;
        //transform.parent.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(xSpeed, ySpeed) + addVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Ground)||
            collision.gameObject.CompareTag(TagName.GroundRight)
            ||collision.gameObject.CompareTag(TagName.GroundBreak)
                        || collision.gameObject.CompareTag(TagName.MoveFloor))
        {
            pScr.IsGround = true;

            //Debug.Log("GROUND TRUE");
        }

        if (collision.gameObject.CompareTag(TagName.MoveFloor))
        {

            //動く床から離れた
            moveObj = collision.gameObject.GetComponent<MoveFloor2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pScr.IsGround) return;

        if (collision.gameObject.CompareTag(TagName.Ground)||
            collision.gameObject.CompareTag(TagName.GroundRight)
                        || collision.gameObject.CompareTag(TagName.GroundBreak)
                                                || collision.gameObject.CompareTag(TagName.MoveFloor))
        {
            pScr.IsGround = true;
            //Debug.Log("GROUND TRUE");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Ground)
            || collision.gameObject.CompareTag(TagName.GroundRight)
                        || collision.gameObject.CompareTag(TagName.GroundBreak)
                                                || collision.gameObject.CompareTag(TagName.MoveFloor))
        {

            pScr.IsGround = false;
            //Debug.Log("GROUND FALSE");
        }

        if (collision.gameObject.CompareTag(TagName.MoveFloor))
        {
            Debug.Log("MoveFloorExit");
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.MoveFloor))
        {
            Debug.Log("MoveFloorExit");
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.MoveFloor))
        {
            Debug.Log("MoveFlooENTER");

            moveObj = collision.gameObject.GetComponent<MoveFloor2D>();
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.LightTransport;

public class MoveFloor2D : MonoBehaviour
{
    [SerializeField] Transform[] moveTrans;
    [SerializeField] int targetNo;
    [SerializeField] float SPEED = 3f;
    [SerializeField] bool isMoveBack = false;

    Rigidbody2D rb2;

    Vector3 moveDir = Vector3.zero;

    Vector2 floorVelocity = Vector2.zero;
    Vector2 oldPos = Vector2.zero;
    bool isOld = false;

    PlayerMove pMove;

    List<Rigidbody2D> rigidBodies = new();
    public Vector2 GetVelocity()
    {
        return floorVelocity;
    }

    void Start()
    {
        pMove = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>();
        rb2 = GetComponent<Rigidbody2D>();

        moveDir = moveTrans[targetNo].position - transform.position;
    }

    private void FixedUpdate()
    {
        //oldfloorVelocity =  floorVelocity;

        float len = Vector2.Distance(transform.position, moveTrans[targetNo].position);
        const float ENDMOVELEN = 0.3f;

        //移動地点に近づいたら移動地点の再設定
        if (len < ENDMOVELEN)
        {
            //移動地点の再設定
            if (!isMoveBack)
                targetNo++;
            else
                targetNo--;

            if (targetNo > moveTrans.Length - 1)
            {
                Debug.Log("RETURN 00");
                isMoveBack = true;
                targetNo--;

            }
            else if (targetNo < 0)
            {
                Debug.Log("RETURN 11");
                targetNo++;
                isMoveBack = false;

            }
                moveDir = moveTrans[targetNo].position - transform.position;


            

        }

        floorVelocity = moveDir.normalized * SPEED * Time.deltaTime;

        //if (isOld)
        //{

        //}
        //else
        //    isOld = true;

        //rb2.MovePosition((Vector2)transform.position + floorVelocity);
        rb2.MovePosition((Vector2)transform.position + (Vector2)moveDir.normalized * SPEED * Time.deltaTime);

        //floorVelocity = (rb2.position - oldPos) / Time.deltaTime;
        //oldPos = rb2.position;

        if (isRide)
        {
            pMove.RideMove(floorVelocity);
           // pMove.m_rb.linearVelocity = pMove.m_rb.position + floorVelocity;
        }

        //AddVelocity();
    }




    bool isRide = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = true;
        }


    }

    ////private void OnTriggerStay2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.CompareTag(TagName.Player))
    ////    {
    ////        Debug.Log("enable");
    ////        var pRb = collision.GetComponent<PlayerMove>().m_rb;
    ////        var pr = pRb.GetPointVelocity(Vector2.zero);
    ////        pRb.MovePosition(pRb.position + pr * Time.deltaTime);
    ////        //Debug.Log("GROUND TRUE");
    ////    }


    ////}

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = false;
        }
    }


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("movePlyerENTER");
    //        rigidBodies.Add(other.gameObject.GetComponent<Rigidbody2D>());
    //    }

    //}



    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //        rigidBodies.Remove(other.gameObject.GetComponent<Rigidbody2D>());
    //}

    //void AddVelocity()
    //{
    //    //if (rb2.linearVelocity.sqrMagnitude <= 0.001f)
    //    //{
    //    //    return;
    //    //}
    //    if(rigidBodies.Count <= 0)
    //    {
    //        return;
    //    }

    //    for (int i = 0; i < rigidBodies.Count; i++)
    //    {
    //        Debug.Log("movePlyer");
    //        rigidBodies[i].AddForce(rb2.linearVelocity);
    //    }
    //}
}

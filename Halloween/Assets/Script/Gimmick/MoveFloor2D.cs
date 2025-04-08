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

    PlayerMove pMove;
    bool isRide = false;

    void Start()
    {
        pMove = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>();
        rb2 = GetComponent<Rigidbody2D>();

        moveDir = moveTrans[targetNo].position - transform.position;
    }

    private void FixedUpdate()
    {

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


        rb2.MovePosition((Vector2)transform.position + floorVelocity);


        //プレイヤーが乗っている時の処理
        if (isRide)
        {
            pMove.RideMove(floorVelocity);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = false;
        }
    }

}

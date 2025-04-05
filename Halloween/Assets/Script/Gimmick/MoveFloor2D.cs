using UnityEngine;

public class MoveFloor2D : MonoBehaviour
{
    [SerializeField] Transform[] moveTrans;
    [SerializeField] int targetNo;
    [SerializeField] float SPEED = 3f;
    [SerializeField] bool isMoveBack = false;

    Rigidbody2D rb2;

    Vector3 moveDir = Vector3.zero;

    Vector2 floorVelocity = Vector2.zero;
    public Vector2 GetVelocity()
    {
        return floorVelocity;
    }

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        moveDir = moveTrans[targetNo].position - transform.position;
    }

    private void FixedUpdate()
    {
        float len = Vector2.Distance(transform.position, moveTrans[targetNo].position);
        const float ENDMOVELEN = 0.1f;
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
                isMoveBack = true;
                targetNo--;
            }
            else if (targetNo < 0)
            {
                targetNo++;
                isMoveBack = false;
            }

            moveDir = moveTrans[targetNo].position - transform.position;

        }

        floorVelocity = (Vector2)moveDir.normalized * (SPEED * Time.fixedDeltaTime);

        rb2.MovePosition(rb2.position + floorVelocity);
        //rb2.MovePosition(transform.position + Time.fixedDeltaTime * moveDir.normalized * SPEED);


    }


}

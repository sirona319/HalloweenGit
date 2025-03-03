using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StraightPointMove : BaseMove
{
    const float ENDMOVELEN = 0.8f;
    public float speed = 7f;

    [SerializeField]Transform[] targets;// = new List<Vector3>();

    int targetNo = 0;

    Vector3 direction;

    public ReactiveProperty<bool> IsLastPointMoveEnd = new ReactiveProperty<bool>(false);
    //public ReactiveProperty<bool[]> IsPointMoveEnd = new ReactiveProperty<bool[]>(new bool[] {false,false });

    public void SetTarget(Transform[] t)
    {
        targets = t;
        direction = targets[0].position - transform.position;

    }

    public override void Initialize()
    {
        base.Initialize();

    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {



        transform.position += direction.normalized * speed * Time.deltaTime;

       
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        if (len < ENDMOVELEN)
        {
            //最後の移動地点へ到着したら
            if (targetNo == targets.Length-1)
                IsLastPointMoveEnd.Value = true;
            else
            {
                targetNo++;
                direction = targets[targetNo].position - transform.position;
            }

           // Debug.Log("目標へ到着");
            //IsPointMoveEnd.Value = true;

        }

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

}

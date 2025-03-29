using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StraightPointMove : BaseMove
{
    [SerializeField] protected List<Transform> movePointLists = new();
    [SerializeField] protected float speed = 4f;
    const float ENDMOVELEN = 0.3f;

    //[SerializeField]Transform[] targets;// = new List<Vector3>();

    protected int targetNo = 0;

    protected Vector3 direction;

    public ReactiveProperty<bool> IsMoveEnd = new ReactiveProperty<bool>(false);
    //public ReactiveProperty<bool[]> IsPointMoveEnd = new ReactiveProperty<bool[]>(new bool[] {false,false });

    TargetSet targetSet;

    public override void Initialize()
    {
        //base.Initialize();
        if (GetComponent<TargetSet>() == null)Debug.Log("TargetSetが未設定;");

        targetSet = GetComponent<TargetSet>();
        targetSet.SetPointArray(movePointLists);
        


        direction = (movePointLists[targetNo].position - transform.position).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        //指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;

       
        float len = Vector3.Distance(transform.position, movePointLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;

        //最後の移動地点へ到着したら
        if (targetNo == movePointLists.Count-1)
            IsMoveEnd.Value = true;
        else
        {
            targetNo++;
            direction = (movePointLists[targetNo].position - transform.position).normalized;
        }

        // Debug.Log("目標へ到着");
        //IsPointMoveEnd.Value = true;

        

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

}

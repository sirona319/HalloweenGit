using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StraightPointMove : BaseMove
{
    public List<Transform> movePointLists = new();
    const float ENDMOVELEN = 0.8f;
    [SerializeField]float speed = 0f;

    //[SerializeField]Transform[] targets;// = new List<Vector3>();

    int targetNo = 0;

    Vector3 direction;

    public ReactiveProperty<bool> IsLastPointMoveEnd = new ReactiveProperty<bool>(false);
    //public ReactiveProperty<bool[]> IsPointMoveEnd = new ReactiveProperty<bool[]>(new bool[] {false,false });

    public void SetTarget(List<Transform> t)
    {
        movePointLists = t;
        direction = (movePointLists[0].position - transform.position).normalized;
        
    }

    public void SetSpeed(float spd,float timing)
    {
        StartCoroutine(MyLib.DelayCoroutine(timing, () =>
        {
            speed = spd;
        }));
    }

    //ノイズ（バグ演出）の時の敵攻撃用
    public void ReTarget(Transform t)
    {
        //movePointLists.Clear();
        movePointLists.Add(t);
        targetNo++;
        direction = (movePointLists[targetNo].position - transform.position).normalized;

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
        //指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;

       
        float len = Vector3.Distance(transform.position, movePointLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;

        //最後の移動地点へ到着したら
        if (targetNo == movePointLists.Count-1)
            IsLastPointMoveEnd.Value = true;
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

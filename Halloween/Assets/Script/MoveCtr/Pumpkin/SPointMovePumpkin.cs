using System.Collections.Generic;
using UnityEngine;

public class SPointMovePumpkin : StraightPointMove
{
    [SerializeField] float delaySetSpeed = 5f;
    [SerializeField] float delaySetTiming = 0f;
    public override void Initialize()
    {

        base.Initialize();

        SetSpeed(delaySetSpeed, delaySetTiming);
        //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    //public void SetTarget(List<Transform> t)
    //{
    //    movePointLists = t;
    //    direction = (movePointLists[0].position - transform.position).normalized;

    //}

    void SetSpeed(float spd, float timing)
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
        moveTransLists.Add(t);
        targetNo++;
        direction = (moveTransLists[targetNo].position - transform.position).normalized;

    }

    //public override void Initialize()
    //{

    //    direction = movePointLists[targetNo].position - transform.position;

    //    //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    //}

    //public override void MoveUpdate()
    //{
    //    //指定ポイント方向へ進み続ける（停止しない）
    //    transform.position += direction.normalized * speed * Timse.deltaTime;


    //    float len = Vector3.Distance(transform.position, movePointLists[targetNo].position);

    //    if (len > ENDMOVELEN)
    //        return;

    //    //最後の移動地点へ到着したら
    //    if (targetNo == movePointLists.Count - 1)
    //        IsMoveEnd.Value = true;
    //    else
    //    {
    //        targetNo++;
    //        direction = (movePointLists[targetNo].position - transform.position).normalized;
    //    }

    //    // Debug.Log("目標へ到着");
    //    //IsPointMoveEnd.Value = true;



    //    //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    //    //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    //}
}

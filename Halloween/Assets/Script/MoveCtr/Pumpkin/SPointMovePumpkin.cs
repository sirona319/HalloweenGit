using System.Collections.Generic;
using UnityEngine;

public class SPointMovePumpkin : StraightPointMove
{

    public void SetTarget(List<Transform> t)
    {
        movePointLists = t;
        direction = (movePointLists[0].position - transform.position).normalized;

    }

    public void SetSpeed(float spd, float timing)
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

        //direction = (movePointLists[targetNo].position - transform.position).normalized;

        //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}

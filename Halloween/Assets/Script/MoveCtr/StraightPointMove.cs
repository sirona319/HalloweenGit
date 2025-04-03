﻿using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StraightPointMove : BaseMove
{
    [SerializeField] protected List<Transform> movePointLists = new();
    [SerializeField] protected float speed = 5f;
    protected float ENDMOVELEN = 0.7f;

    //[SerializeField]Transform[] targets;// = new List<Vector3>();

    protected int targetNo = 0;

    protected Vector3 direction;

    protected ReactiveProperty<bool> IsMoveEnd = new ReactiveProperty<bool>(false);
    //public ReactiveProperty<bool[]> IsPointMoveEnd = new ReactiveProperty<bool[]>(new bool[] {false,false });

    TargetSet targetSet;

    //Rigidbody rb2;

    public override void Initialize()
    {

        //base.Initialize();
        //if (GetComponent<TargetSet>() == null)Debug.Log("TargetSetが未設定;");
        if (gameObject.GetComponent<TargetSet>()!=null)
        {
            targetSet = GetComponent<TargetSet>();
            movePointLists = targetSet.SetPointArray(movePointLists);
        }

        //rb2=GetComponent<Rigidbody>();
        direction = (movePointLists[targetNo].position - transform.position).normalized;

        //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        //指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;
        //rb2.MovePosition(rb2.position + direction * speed * Time.deltaTime);


        float len = Vector3.Distance(transform.position, movePointLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;


        //if (len < ENDMOVELEN)
        //{

            //最後の移動地点へ到着したら
            if (targetNo == movePointLists.Count - 1)
                IsMoveEnd.Value = true;
            else
            {
                targetNo++;
                direction = (movePointLists[targetNo].position - transform.position).normalized;
            }
        //}
        // Debug.Log("目標へ到着");
        //IsPointMoveEnd.Value = true;

        


        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

}

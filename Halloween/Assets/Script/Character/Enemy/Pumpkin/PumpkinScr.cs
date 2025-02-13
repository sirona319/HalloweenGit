using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScr : EnemyBase
{
    public bool isBoss = false;
    void Start()
    {
        base.StartInit();
        base.Init();



        stateController.Initialize((int)FlyCtr.State.Fly_Wait);
    }

    void Update()
    {
        AttackTimeUpdate();

        //if (transform.position.z != 0f)
        //{
        //    var tr = transform.position;
        //    tr.z = 0f;
        //    transform.position = tr;
        //}

        stateController.UpdateSequence();

        //ResetPos2DZ();
    }

    void ResetPos2DZ()
    {
        if (transform.position.z == 0f)
            return;

        var tr = transform.position;
        tr.z = 0f;
        transform.position = tr;
        
    }

    //private void FixedUpdate()
    //{
    //    if(transform.position.z!=0f)
    //    {
    //        var tr = transform.position;
    //        tr.z = 0f;
    //        transform.position = tr;
    //    }
    //}


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int FlyReturnStateType(int stateType)
    {
        if (AtkInterval <= 0)
            return (int)FlyCtr.State.Fly_Attack;
        else if (IsMove)
            return (int)FlyCtr.State.Fly_Move;

        else
            return (int)FlyCtr.State.Fly_Wait;

    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Test");
    //    if (!other.gameObject.CompareTag("Player"))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.gameObject.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}

    //private void OnCollisionEnter2D(Collider2D other)
    //{

    //    if (!other.transform.CompareTag("Player"))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}

}

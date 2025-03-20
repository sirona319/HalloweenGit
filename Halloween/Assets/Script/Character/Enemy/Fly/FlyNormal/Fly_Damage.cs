﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fly_Damage : StateChildBase
{
    const float DAMAGETIMEMAX = 0.4f;
    //float damageTime = 0f;

    //Animator m_anim;

    //void Start()
    //{
    //    m_anim = gameObject.GetComponent<Animator>();
    //}

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        //m_anim = gameObject.GetComponent<Animator>();
    }
    public override void OnEnter()
    {
        //damageTime = 0f;
        stateTime = 0f;
        //オブジェクトを揺らしオン
        StartCoroutine(MyLib.DoShake(0.25f, 0.1f, transform));

        //死んでいたら
        //if (gameObject.GetComponent<EnemyBase>().isDead) return;


        //if (GetComponent<EnemyBase>().HitCol.enabled)
        //{
        //    Debug.Log("ダメージアニメ開始　敵の攻撃判定を切る");
        //    GetComponent<EnemyBase>().HitCol.enabled = false;
        //}

        //if (!m_anim.GetBool("DamageB"))
         //   m_anim.SetBool("DamageB", true);

        //damageTime = DAMAGETIMEMAX;
        //コルーチンの起動
       // StartCoroutine(MyLib.DelayCoroutine(damageTime, () =>
        //{
           // m_anim.SetBool("DamageB", false);
       //}));

    }

    public override void OnExit()
    {
        gameObject.GetComponent<EnemyBase>().isDamage = false;
        //gameObject.GetComponent<Animator>().SetBool("DamageB", false);
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (gameObject.GetComponent<EnemyBase>().isDead)
        {
            const int DEAD = 2;
            return DEAD;
        }

        if (stateTime >= DAMAGETIMEMAX)
        {

            return GetComponent<EnemyBase>().ReturnStateMoveType(StateType);
        }

        return StateType;
    }

}

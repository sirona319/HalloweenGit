using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Pumpkin_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        GetComponent<PumpkinScr>().AtkInterval = GetComponent<PumpkinScr>().enemyData.AtkIntervalMax;
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        //foreach (var magazine in GetComponent<FlyScr>().baseMagazine)
        //    magazine.MagazineEnter();
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;


        if (GetComponent<EnemyBase>().IsDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)FlyCtr.State.Fly_Dead;



        //マガジンの更新
        //GetComponent<FlyScr>().AttackMagazineUpdateAll();



        if (stateTime > GetComponent<EnemyBase>().AtkInterval)
        {
            GetComponent<EnemyBase>().AtkInterval = GetComponent<EnemyBase>().enemyData.AtkIntervalMax;
            //GetComponent<FlyScr>().IsAttack = false;
            return GetComponent<PumpkinScr>().FlyReturnStateType(StateType);
        }


        return (int)StateType;
    }

}

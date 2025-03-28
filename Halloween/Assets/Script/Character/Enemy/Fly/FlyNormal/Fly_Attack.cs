using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fly_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {

        base.Initialize(stateType);
        //GetComponent<FlyScr>().AtkInterval = GetComponent<FlyScr>().MaxAtkInterval;

        //GetComponent<FlyScr>().AttackMagazineUpdateAll();
        GetComponent<FlyScr>().atkMove.Initialize();
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        //foreach (var magazine in GetComponent<FlyScr>().baseMagazine)
        //    magazine.MagazineEnter();

        GetComponent<FlyScr>().atkMove.MoveEnter();
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;


        if (GetComponent<IDamage>().IsDamage)
            if (GetComponent<FlyScr>().ReturnStateTypeDead())
                return (int)FlyCtr.State.Fly_Dead;



        //マガジンの更新
        //GetComponent<FlyScr>().AttackMagazineUpdateAll();
        GetComponent<FlyScr>().atkMove.MoveUpdate();


        if (!GetComponent<FlyScr>().isAttack)
        {
            //GetComponent<FlyScr>().AtkInterval = GetComponent<FlyScr>().MaxAtkInterval;
            //GetComponent<FlyScr>().isAttack = false;
            return GetComponent<FlyScr>().FlyReturnStateType(StateType);
        }




        return (int)StateType;
    }

}

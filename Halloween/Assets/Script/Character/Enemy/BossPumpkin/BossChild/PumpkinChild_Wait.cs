using System;
using UnityEditor;
using UnityEngine;

public class PumpkinChild_Wait : StateChildBase
{
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

    }

    public override void OnEnter()
    {
        stateTime = 0f;
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 5f);

        if (GetComponent<PumpkinBossChildScr>().isAllFallEnd && GetComponent<PumpkinBossChildScr>().isSpawnMove)
        {
            return (int)PumpkinBossChildCtr.State.PumpkinChild_Move;
        }

        if ( GetComponent<PumpkinBossChildScr>().isFallMove)
        {
            return (int)PumpkinBossChildCtr.State.PumpkinChild_Fall;
        }

        //if (GetComponent<IDamage>().IsDamage)
        //     return GetComponent<PomuScr>().DamageCheck();

        stateTime += Time.deltaTime;

        return StateType;
        //return GetComponent<PomuScr>().ReturnStateType(StateType);

    }
}

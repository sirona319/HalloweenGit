using System;
using UnityEditor;
using UnityEngine;

public class PumpkinChild_Move : StateChildBase
{
    BaseMove spawnMove;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
        spawnMove = GetComponent<SpawnPumpkinChild>();

        spawnMove.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;
        spawnMove.MoveEnter();
    }

    public override void OnExit()
    {
        spawnMove.MoveExit();
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        spawnMove.MoveUpdate();

        return GetComponent<PumpkinBossChildScr>().PumpkinStateType(StateType);

    }
}

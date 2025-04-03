using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PumpkinChild_Fall : StateChildBase
{
    BaseMove fallMove;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        if (GetComponent<FallPumpkinChild>() == null) return;
        fallMove = GetComponent<FallPumpkinChild>();
        fallMove.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;
        fallMove.MoveEnter();
    }

    public override void OnExit()
    {
        fallMove.MoveExit();
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        fallMove.MoveUpdate();

        if(!GetComponent<PumpkinBossChildScr>().isFallMove)
            return GetComponent<PumpkinBossChildScr>().PumpkinStateType(StateType);

        return StateType;

    }
}

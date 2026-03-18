using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_Dead : StateChildBase
{

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
    }

    public override void OnEnter()
    {

        Debug.Log("PumpkinBoss_Dead");
    }

    public override void OnExit()
    {

    }

    public override sealed int StateUpdate()
    {
        stateTime += Time.deltaTime;

        return (int)StateType;

    }
}

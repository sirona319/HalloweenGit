using UnityEngine;

public class FlyScr : EnemyBase
{
    public float MaxAtkInterval = 1f;
    public float AtkInterval =1;
    void Start()
    {
        base.StartInit();

        stateController.Initialize((int)FlyCtr.State.Fly_Wait);
    }

    void Update()
    {
        AttackTimeUpdate();

        stateController.UpdateSequence();

    }

    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        AtkInterval -= Time.deltaTime;

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

}

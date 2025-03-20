using UnityEngine;

public class PomuScr : EnemyBase
{
    //public float MaxAtkInterval = 1f;
    //public float AtkInterval = 1;
    void Start()
    {
        base.StartInit();

        stateController.Initialize((int)FlyCtr.State.Fly_Wait);
    }

    void Update()
    {
        //AttackTimeUpdate();

        stateController.UpdateSequence();

    }

    //void AttackTimeUpdate()
    //{
    //    if (!isAttack) return;

    //    AtkInterval -= Time.deltaTime;

    //}

    public int ReturnStateType(int stateType)
    {
        if (isMove)
            return (int)PomuCtr.State.Pomu_Move;

        else
            return (int)PomuCtr.State.Pomu_Wait;

    }
}

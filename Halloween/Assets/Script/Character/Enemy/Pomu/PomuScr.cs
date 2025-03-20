using UnityEngine;

public class PomuScr : EnemyBase
{
    //public float MaxAtkInterval = 1f;
    //public float AtkInterval = 1;
    void Start()
    {
        //base.StartInit();

        stateController.Initialize((int)PomuCtr.State.Pomu_Move);
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

    //public int ReturnStateType(int stateType)
    //{
    //    if (isMove)
    //        return (int)PomuCtr.State.Pomu_Move;

    //    else
    //        return (int)PomuCtr.State.Pomu_Wait;

    //}

    public int DamageCheck()
    {

        //if (GetComponent<EnemyBase>().isDamage)
        if (GetComponent<EnemyBase>().ReturnStateTypeDead())
            return (int)PomuCtr.State.Pomu_Dead;
        else
            return (int)PomuCtr.State.Pomu_Damage;

    }
}

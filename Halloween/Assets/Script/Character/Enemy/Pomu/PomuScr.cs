using UnityEngine;

public class PomuScr : EnemyBase
{
    [SerializeField] EnemyDamage eDamage;
    //public bool isAttack = true;
    public bool isMove = true;

    //public float MaxAtkInterval = 1f;
    //public float AtkInterval = 1;
    public BaseMove move;
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
        if (ReturnStateTypeDead())
            return (int)PomuCtr.State.Pomu_Dead;
        else
            return (int)PomuCtr.State.Pomu_Damage;

    }

    public bool ReturnStateTypeDead()
    {
        if (isDead) return true;

        return false;
    }

    public int ReturnStateType(int stateType)
    {
        //if (isAttack)
        //    return (int)FlyCtr.State.Fly_Attack;

        //else
        if (isMove)
            return (int)FlyCtr.State.Fly_Move;


        return stateType;
    }
}

using UnityEngine;

public class FlyScr : EnemyBase
{
    //public float MaxAtkInterval = 1f;
    //public float AtkInterval =1;

    public BaseMove atkMove;
    public BaseMove move;

    public bool isAttack = true;
    public bool isMove = true;

    [SerializeField] EnemyDamage eDamage;

    public bool ReturnStateTypeDead()
    {
        if (isDead) return true;

        return false;
    }

    public int ReturnStateType(int stateType)
    {
        if (isAttack)
            return (int)FlyCtr.State.Fly_Attack;

        else if (isMove)
            return (int)FlyCtr.State.Fly_Move;


        return stateType;
    }

    void Start()
    {
        //base.StartInit();

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

    public int FlyReturnStateType(int stateType)
    {
        if (isAttack)
            return (int)FlyCtr.State.Fly_Attack;

        else if (isMove)
            return (int)FlyCtr.State.Fly_Move;

        else
            return (int)FlyCtr.State.Fly_Wait;



    }

}

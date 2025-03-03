using UnityEngine;

public class Pumpkin_Move : StateChildBase
{
    PumpkinScr pScr;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        pScr = GetComponent<PumpkinScr>();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in pScr.baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
        {
            return (int)PumpkinCtr.State.Pumpkin_Damage;
        }
            //if (GetComponent<EnemyBase>().IsDamage)
            //    if (GetComponent<EnemyBase>().ReturnStateTypeDead())
            //        return (int)FlyCtr.State.Fly_Dead;


        //移動の更新
        foreach (var move in pScr.baseMove)
        {
            move.MoveUpdate();
            //GetComponent<FlyScr>().IsMove = move.IsMove;
        }

        if (!pScr.IsMove)
            pScr.IsAttack = true;

        return (int)StateType;

    }

}

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

        if (GetComponent<EnemyBase>().isDamage)
        {
            return (int)PumpkinCtr.State.Pumpkin_Damage;
        }
            //if (GetComponent<EnemyBase>().isDamage)
            //    if (GetComponent<EnemyBase>().ReturnStateTypeDead())
            //        return (int)FlyCtr.State.Fly_Dead;


        //移動の更新
        foreach (var move in pScr.baseMove)
        {
            move.MoveUpdate();
            //GetComponent<FlyScr>().isMove = move.isMove;
        }

        if (!pScr.isMove)
            pScr.isAttack = true;

        return (int)StateType;

    }

}

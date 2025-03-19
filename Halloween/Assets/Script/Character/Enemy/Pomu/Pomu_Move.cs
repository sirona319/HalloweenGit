using UnityEngine;

public class Pomu_Move : StateChildBase
{
    PomuScr pScr;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        pScr = GetComponent<PomuScr>();
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
            return (int)PomuCtr.State.Pomu_Damage;
        }


        //移動の更新
        foreach (var move in pScr.baseMove)
        {
            move.MoveUpdate();
        }

        //if (!pScr.isMove)
        //    pScr.isAttack = true;

        return (int)StateType;

    }
}

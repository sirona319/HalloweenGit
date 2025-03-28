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

        // foreach (var move in pScr.baseMove)
        pScr.move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<IDamage>().IsDamage)
            return pScr.DamageCheck();



        //移動の更新
        //foreach (var move in pScr.baseMove)
       // {
            pScr.move.MoveUpdate();
            //GetComponent<FlyScr>().isMove = move.isMove;
        //}

        //if (!pScr.isMove)
        //    pScr.isAttack = true;

        return (int)StateType;

    }

}

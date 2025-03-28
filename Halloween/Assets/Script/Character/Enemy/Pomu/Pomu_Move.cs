using UnityEngine;

public class Pomu_Move : StateChildBase
{
    PomuScr pScr;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        pScr = GetComponent<PomuScr>();
        pScr.move.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //foreach (var move in pScr.baseMove)
            GetComponent<PomuScr>().move.MoveEnter();

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

            return GetComponent<PomuScr>().DamageCheck();


        //移動の更新
        //foreach (var move in pScr.baseMove)
        //{
            GetComponent<PomuScr>().move.MoveUpdate();
        //}

        //if (!pScr.isMove)
        //    pScr.isAttack = true;

        if (!pScr.isMove)
            return (int)pScr.ReturnStateType(StateType);

        return (int)StateType;

    }
}

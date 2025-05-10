using UnityEditor.Rendering;
using UnityEngine;

public class Pomu_Move : StateChildBase
{
    PomuScr pScr;
    BaseMagazine atkMagazine = null;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        pScr = GetComponent<PomuScr>();
        pScr.move.Initialize();

        if (GetComponent<BaseMagazine>() != null)
        {
            atkMagazine = GetComponent<BaseMagazine>();
            atkMagazine.Initialize();
            atkMagazine.enabled = false;
        }

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        if(atkMagazine != null)
            if(atkMagazine.enabled)
            atkMagazine.MagazineEnter();

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

        if (atkMagazine != null)
            if (atkMagazine.enabled)
                atkMagazine.MagazineUpdate();

        if (!pScr.isMove)
            return (int)pScr.ReturnStateType(StateType);

        return (int)StateType;

    }
}

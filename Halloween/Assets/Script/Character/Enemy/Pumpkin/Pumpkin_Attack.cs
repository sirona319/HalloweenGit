using UnityEngine;

public class Pumpkin_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        //GetComponent<PumpkinScr>().AtkInterval = GetComponent<PumpkinScr>().enemyData.AtkIntervalMax;
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        //foreach (var magazine in GetComponent<FlyScr>().baseMagazine)
        //    magazine.MagazineEnter();
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;


        if (GetComponent<EnemyBase>().isDamage)
            return GetComponent<PumpkinScr>().DamageCheck();



        //マガジンの更新
        //GetComponent<FlyScr>().AttackMagazineUpdateAll();



        //if (stateTime > GetComponent<PumpkinScr>().AtkInterval)
        //{
        //    GetComponent<PumpkinScr>().AtkInterval = GetComponent<EnemyBase>().enemyData.AtkIntervalMax;
        //    //GetComponent<FlyScr>().isAttack = false;
        //    return GetComponent<PumpkinScr>().FlyReturnStateType(StateType);
        //}


        return (int)StateType;
    }

}

using UnityEngine;

public class PumpkinBoss_Wait : StateChildBase
{
    PumpkinBossScr bossScr;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        bossScr = GetComponent<PumpkinBossScr>();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        if (bossScr.pumpkinChildDeadCount == 6)
            Debug.Log("Lv2移行");
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 5f);

        //if (GetComponent<PumpkinBossScr>().IsDamage)
        //    if (GetComponent<PumpkinBossScr>().ReturnStateTypeDead())
        //        return (int)FlyCtr.State.Fly_Dead;

        stateTime += Time.deltaTime;

        if (!GetComponent<PumpkinBossScr>().startBattle)return StateType;

        if (bossScr.pumpkinChildDeadCount == 6)
        {
            bool isFallEnd = false;
            foreach (var f in bossScr.pumpkinsLv2)
                isFallEnd = f.GetComponent<PumpkinChild>().isFall;


            //全てのかぼちゃが落下し終わっていたら
            if (isFallEnd)
                return (int)PumpkinBossCtr.State.PumpkinBoss_AttackL2;
            else
                return (int)PumpkinBossCtr.State.PumpkinBoss_Fall;//かぼちゃを落とす
        }
        

        //if (GetComponent<PumpkinBossScr>().startBattle)
        if (bossScr.pumpkinChildDeadCount == 0)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Attack;

        //return GetComponent<EnemyBase>().ReturnStateMoveTypeAttack(StateType);


        //if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.circle)
        //    return (int)SlimeCtr.State.Slime_CircleAttack;
        //else if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.five)
        //    return (int)SlimeCtr.State.Slime_FiveAttack;
        //else
        //    return (int)SlimeCtr.State.Slime_Attack;

        //if (GetComponent<EnemyBase>().moveType == EnemyBase.MoveType.random)
        //    return (int)SlimeCtr.State.Slime_CircleAttack;
        //else if (GetComponent<EnemyBase>().moveType == EnemyBase.MoveType.point)
        //    return (int)SlimeCtr.State.Slime_MovePoint;//　ポイントムーブ

        return StateType;//GetComponent<PumpkinBossScr>().FlyReturnStateType(StateType);


        //return StateType;
    }
}

using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
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

        if (bossScr.pumpkinChildDeadCount == 16)
            Debug.Log("Lv3移行");
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
        if (!GetComponent<PumpkinBossScr>().startBattle) return StateType;





        //if (bossScr.pumpkinChildDeadCount == 31)
        //{
        //    GetComponent<PumpkinBossScr>().startBattle = false;
        //    GetComponent<PumpkinBossScr>().BattleEnd();
        //    Debug.Log("戦闘終了");
        //}

        if (bossScr.pumpkinChildDeadCount == 16)
        {
            bool isFallEnd = false;
            foreach (var f in bossScr.pumpkinsLv3)
                isFallEnd = f.GetComponent<PumpkinChild>().isFall;


            //全てのかぼちゃが落下し終わっていたら
            if (isFallEnd)
                return (int)PumpkinBossCtr.State.PumpkinBoss_AttackL3;
            else
            {
                GetComponent<PumpkinBoss_Fall>().pumpkinsArray = bossScr.pumpkinsLv3;
                GetComponent<PumpkinBoss_Fall>().maxCountPumpkin = 14;
                return (int)PumpkinBossCtr.State.PumpkinBoss_Fall;//かぼちゃを落とす

            }
        }


        if (bossScr.pumpkinChildDeadCount == 6)
        {
            bool isFallEnd = false;
            foreach (var f in bossScr.pumpkinsLv2)
                isFallEnd = f.GetComponent<PumpkinChild>().isFall;



            //全てのかぼちゃが落下し終わっていたら
            if (isFallEnd)
                return (int)PumpkinBossCtr.State.PumpkinBoss_AttackL2;
            else
            {
                //フォールクラスの設定
                //foreach (var go in bossScr.pumpkinsLv2List)
                //{
                    GetComponent<PumpkinBoss_Fall>().pumpkinsArray = bossScr.pumpkinsLv2;
                    //GetComponent<PumpkinBoss_FallL2>().pumpkins = new List<GameObject>(bossScr.pumpkinsLv2List);
                //}

                return (int)PumpkinBossCtr.State.PumpkinBoss_Fall;//かぼちゃを落とす

            }
        }

        if (bossScr.pumpkinChildDeadCount == 0)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Attack;
        //if (GetComponent<PumpkinBossScr>().startBattle)


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

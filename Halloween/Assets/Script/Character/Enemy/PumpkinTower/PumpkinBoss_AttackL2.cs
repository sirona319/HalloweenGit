using System.Collections;
using UnityEngine;

public class PumpkinBoss_AttackL2 : StateChildBase
{
    PumpkinBossScr bossScr;

    //public bool isTest = false;

    public IEnumerator AtkEnable()
    {

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 6);//trueなら

        //Lv1
        bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[1].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[2].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[3].GetComponent<RotModule>().enabled = true;

        bossScr.pumpkinsLv2[0].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[1].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[2].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[3].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < 10f, () =>
        {
            if (bossScr.pumpkinsLv2[0] != null)
            {
                bossScr.pumpkinsLv2[0].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[1].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[2].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[3].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));


        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 10);//trueなら



    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;

        bossScr.pumpkinsLv2[0].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            if (bossScr.pumpkinsLv2[0] != null)
            {
                bossScr.pumpkinsLv2[0].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 6);



    }

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        bossScr = GetComponent<PumpkinBossScr>();

    }

    public override void OnEnter()
    {

        stateTime = 0f;

        StartCoroutine(AtkEnable());

    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (bossScr.pumpkinChildDeadCount == 13)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

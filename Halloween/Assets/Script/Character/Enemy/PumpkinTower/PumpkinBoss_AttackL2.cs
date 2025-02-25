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

        //Lv2
        bossScr.pumpkinsLv2[4].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[5].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[6].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[7].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[8].GetComponent<RotModule>().enabled = true;

        bossScr.pumpkinsLv2[4].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[5].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[6].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[7].GetComponent<PumpkinChildMove>().Initialize();
        bossScr.pumpkinsLv2[8].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < 22f, () => {         
            if (bossScr.pumpkinsLv2[4] != null&&
            bossScr.pumpkinsLv2[5] != null&&
            bossScr.pumpkinsLv2[6] != null&&
            bossScr.pumpkinsLv2[7] != null&&
            bossScr.pumpkinsLv2[8] != null
            )
            {
                bossScr.pumpkinsLv2[4].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[5].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[6].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[7].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                bossScr.pumpkinsLv2[8].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().isShakeEnd);
        //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);//trueなら

        bossScr.pumpkinsLv2[9].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < 35, () =>
        {
            if (bossScr.pumpkinsLv2[9] != null)
            {
                bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));

    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinChildDeadCount = 15;
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().isShakeEnd);
        //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);//trueなら

        bossScr.pumpkinsLv2[9].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < 35, () =>
        {
            if (bossScr.pumpkinsLv2[9] != null)
            {
                bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));



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
        //StartCoroutine(DEBUGAtkEnable());
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (bossScr.pumpkinChildDeadCount == 16)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

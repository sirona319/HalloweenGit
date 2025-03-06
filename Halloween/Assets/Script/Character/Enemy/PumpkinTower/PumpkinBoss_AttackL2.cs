using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_AttackL2 : StateChildBase
{
    PumpkinBossScr bossScr;

    List<PumpkinChild> childList = new List<PumpkinChild>();
    public IEnumerator AtkEnable()
    {
        //Lv1
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 6);//trueなら

        bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[1].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[2].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[3].GetComponent<RotModule>().enabled = true;

        childList.Add(bossScr.pumpkinsLv2[0].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[1].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[2].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[3].GetComponent<PumpkinChild>());

        //Lv2
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 10);//trueなら

        bossScr.pumpkinsLv2[4].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv2[5].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv2[6].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv2[7].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv2[8].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv2[4].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[5].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[6].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[7].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv2[8].GetComponent<PumpkinChild>());

        //Lv3
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);

        //赤かぼちゃアニメーションなど
        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildRed>().isShakeEnd);

        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv2[9].GetComponent<PumpkinChild>());

    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinChildDeadCount = 15;
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<PumpkinChildRed>().isShakeEnd);


        bossScr.pumpkinsLv2[9].GetComponent<RotModule>().enabled = true;

        StartCoroutine(MyLib.LoopDelayCoroutine(0,() =>
        {
            if (bossScr.pumpkinsLv2[9] != null)
            {
                bossScr.pumpkinsLv2[9].GetComponent<PumpkinChild>().MoveUpdateNoRot();
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
        childList.Clear();
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        foreach (var p in childList)
            p.MoveUpdateNoRot();
        

        if (bossScr.pumpkinChildDeadCount == 16)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

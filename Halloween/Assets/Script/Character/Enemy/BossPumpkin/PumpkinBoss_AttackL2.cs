using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PumpkinBoss_AttackL2 : StateChildBase
{
    PumpkinBossScr bossScr;

    //List<PumpkinBossChildScr> childList = new ();

    void SetPumpkinChild(int n)
    {
        const float atkRotSpd = 30f;
        bossScr.pumpkinsLv2[n].GetComponent<RotModule>().speed = atkRotSpd;
        //bossScr.pumpkinsLv2[n].GetComponent<RotModule>().enabled = true;
        //childList.Add(bossScr.pumpkinsLv2[n].GetComponent<PumpkinBossChildScr>());
        bossScr.pumpkinsLv2[n].GetComponent<PumpkinBossChildScr>().isSpawnMove = true;
    }
    public IEnumerator AtkEnable()
    {
        //Lv1
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 6);//trueなら

        SetPumpkinChild(0);
        SetPumpkinChild(1);
        SetPumpkinChild(2);
        SetPumpkinChild(3);

        //Lv2
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 10);//trueなら

        SetPumpkinChild(4);
        SetPumpkinChild(5);
        SetPumpkinChild(6);
        SetPumpkinChild(7);
        SetPumpkinChild(8);

        //Lv3
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);

        //赤かぼちゃアニメーションなど
        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<AnimEventShakeScr>().isShakeEnd);

        SetPumpkinChild(9);

    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinChildDeadCount = 15;
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv2[9].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 15 &&
                                        bossScr.pumpkinsLv2[9].GetComponent<AnimEventShakeScr>().isShakeEnd);

        SetPumpkinChild(8);
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
        //childList.Clear();
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        //foreach (var p in childList)
       //     p.MoveUpdateNoRot();
        

        if (bossScr.pumpkinChildDeadCount == 16)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

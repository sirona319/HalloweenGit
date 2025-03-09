using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_AttackL3 : StateChildBase
{
    PumpkinBossScr bossScr;

    const int lastNo = 14;
    const int lastDesdCount = 30;

    //リストを作成して　入れたオブジェクトのアップデートを回すようにする？ (不具合があれば？コルーチン)
    List<PumpkinChild> childList=new List<PumpkinChild>();

    void SetPumpkinChild(int n)
    {
        const float atkRotSpd = 30f;
        bossScr.pumpkinsLv3[n].GetComponent<RotModule>().speed = atkRotSpd;
        bossScr.pumpkinsLv3[n].GetComponent<RotModule>().enabled = true;
        childList.Add(bossScr.pumpkinsLv3[n].GetComponent<PumpkinChild>());
    }
    public IEnumerator AtkEnable()
    {
        //Lv1
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount >= 16);//trueなら

        //SetPumpkinChild(0);
        //SetPumpkinChild(1);
        //SetPumpkinChild(3);
        //SetPumpkinChild(4);

        //LV2
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount >= 20);//trueなら

        //SetPumpkinChild(2);
        //SetPumpkinChild(5);
        //SetPumpkinChild(6);
        //SetPumpkinChild(7);
        //SetPumpkinChild(8);

        //LV3
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount >= 25);//trueなら

        SetPumpkinChild(9);
        SetPumpkinChild(10);
        SetPumpkinChild(11);
        SetPumpkinChild(12);
        SetPumpkinChild(13);

        //LV4
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount >= lastDesdCount);//30
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv3[lastNo].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
        //                                bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChildRed>().isShakeEnd);
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
                                bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChildRedTwo>().isShakeEnd);

        SetPumpkinChild(lastNo);
    }

    public IEnumerator DEBUGAtkEnable()
    {

        bossScr.pumpkinChildDeadCount = lastDesdCount;
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv3[lastNo].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
                                        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChildRed>().isShakeEnd);

        bossScr.pumpkinsLv3[lastNo].GetComponent<RotModule>().enabled = true;

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            if (bossScr.pumpkinsLv3[lastNo] != null)
            {
                bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().MoveUpdateNoRot();
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

        if (bossScr.pumpkinChildDeadCount == 31)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

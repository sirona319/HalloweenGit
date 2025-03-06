using NUnit.Framework;
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

    public IEnumerator AtkEnable()
    {
        //Lv1
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 16);//trueなら


        bossScr.pumpkinsLv3[0].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[1].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[3].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[4].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv3[0].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[1].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[3].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[4].GetComponent<PumpkinChild>());

        //LV2
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 20);//trueなら

        bossScr.pumpkinsLv3[4].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[5].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[6].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[7].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[8].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv3[2].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[5].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[6].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[7].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[8].GetComponent<PumpkinChild>());

        //LV3
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 25);//trueなら

        bossScr.pumpkinsLv3[9].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[10].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[11].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[12].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[13].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv3[9].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[10].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[11].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[12].GetComponent<PumpkinChild>());
        childList.Add(bossScr.pumpkinsLv3[13].GetComponent<PumpkinChild>());

        //LV4
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv3[lastNo].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
                                        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChildRed>().isShakeEnd);


        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().Initialize();

        childList.Add(bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>());
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_Attack : StateChildBase
{

    PumpkinBossScr bossScr;
    List<PumpkinChild> childList = new List<PumpkinChild>();

    void SetPumpkinChild(int n)
    {
        const float atkRotSpd = 30f;
        bossScr.pumpkins[n].GetComponent<RotModule>().speed = atkRotSpd;
        bossScr.pumpkins[n].GetComponent<RotModule>().enabled = true;
        childList.Add(bossScr.pumpkins[n].GetComponent<PumpkinChild>());
    }
    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        bossScr = GetComponent<PumpkinBossScr>();
        //GetComponent<PumpkinScr>().AtkInterval = GetComponent<PumpkinScr>().enemyData.AtkIntervalMax;
    }

    public IEnumerator AtkEnable()
    {
        //Lv1
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 0);//trueなら
        SetPumpkinChild(0);
        SetPumpkinChild(1);

        //Lv2
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 2);
                                                                                                                                                //yield return new WaitWhile(条件);falseなら
        SetPumpkinChild(2);
        SetPumpkinChild(3);
        SetPumpkinChild(4);

        //Lv3
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkins[5].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5&& 
                                        bossScr.pumpkins[5].GetComponent<PumpkinChildRed>().isShakeEnd);

        SetPumpkinChild(5);

    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinChildDeadCount = 5;

        var anim = bossScr.pumpkins[5].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5 &&
                                        bossScr.pumpkins[5].GetComponent<PumpkinChildRed>().isShakeEnd);
        SetPumpkinChild(5);

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //画面外に行き　当たり判定のある　敵を生成
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
            p.MoveUpdateNoRotisFall();
        

        if (bossScr.pumpkinChildDeadCount == 6)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

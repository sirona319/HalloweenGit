using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PumpkinBoss_Attack : StateChildBase
{
    //bool isAtkLife = true;

    //int atkCountLv0 = 6; //6 10 15
    //int atkCountLv1 = 10; //6 10 15
    //int atkCountLv2 = 15; //6 10 15


    //int isAtkLv = 0;

    PumpkinBossScr bossScr;

    const float Lv1LimitTime = 10f;
    const float Lv2LimitTime = 22f;
    //const float Lv3LimitTime = 10f;

    //public bool isTest = false;
    //bool isShake = false;
    public IEnumerator AtkEnable()
    {

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 0);//trueなら

        //Lv1
        bossScr.pumpkins[0].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkins[1].GetComponent<RotModule>().enabled = true;

        bossScr.pumpkins[0].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkins[1].GetComponent<PumpkinChild>().Initialize();
        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime< Lv1LimitTime, () =>
        {
            if (bossScr.pumpkins[0] != null)
            {
                bossScr.pumpkins[0].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
                bossScr.pumpkins[1].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
            }

        }));


        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 2);//trueなら
                                                                             //                                                                     //yield return new WaitWhile(条件);falseなら

        ////上　ななめ　攻撃        //Lv2
        bossScr.pumpkins[2].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkins[3].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkins[4].GetComponent<RotModule>().enabled = true;

        bossScr.pumpkins[2].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkins[3].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkins[4].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < Lv2LimitTime, () =>
        {
            if (bossScr.pumpkins[2] != null)
            {
                bossScr.pumpkins[2].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
                bossScr.pumpkins[3].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
                bossScr.pumpkins[4].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
            }

        }));

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkins[5].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5&& 
                                        bossScr.pumpkins[5].GetComponent<PumpkinChildRed>().isShakeEnd);

        bossScr.pumpkins[5].GetComponent<RotModule>().enabled = true;
        ////ボスかぼちゃ　ピンボール        //Lv3
        ///
        bossScr.pumpkins[5].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0,() =>
        {
            if (bossScr.pumpkins[5] != null)
            {
                bossScr.pumpkins[5].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
            }

        }));


    }

    public IEnumerator DEBUGAtkEnable()
    {
        bossScr.pumpkinChildDeadCount = 5;

        var anim = bossScr.pumpkins[5].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5 &&
                                        bossScr.pumpkins[5].GetComponent<PumpkinChildRed>().isShakeEnd);

        //bossScr.pumpkins[5].GetComponent<RotModule>().enabled = true;
        ////ボスかぼちゃ　ピンボール        //Lv3
        ///
        bossScr.pumpkins[5].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            if (bossScr.pumpkins[5] != null)
            {
                bossScr.pumpkins[5].GetComponent<PumpkinChild>().MoveUpdateNoRotisFall();
            }

        }));



    }

    //public IEnumerator Lv3(Action action)
    //{

    //    yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 5);//trueなら
    //    //yield return new WaitWhile(条件);falseなら

    //    action.Invoke();
    //}

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        bossScr = GetComponent<PumpkinBossScr>();
        //GetComponent<PumpkinScr>().AtkInterval = GetComponent<PumpkinScr>().enemyData.AtkIntervalMax;
    }

    public override void OnEnter()
    {

        stateTime = 0f;

        //画面外に行き　当たり判定のある　敵を生成
        //StartCoroutine(AtkEnable());
        StartCoroutine(DEBUGAtkEnable());
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (bossScr.pumpkinChildDeadCount == 6)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

            return (int)StateType;
    }
}

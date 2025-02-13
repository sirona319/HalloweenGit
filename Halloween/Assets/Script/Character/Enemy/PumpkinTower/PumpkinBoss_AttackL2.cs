using System.Collections;
using UnityEngine;

public class PumpkinBoss_AttackL2 : StateChildBase
{
    PumpkinBossScr bossScr;

    //public bool isTest = false;

    public IEnumerator AtkEnable()
    {

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 6);//trueなら

        //StartCoroutine(MyLib.DelayCoroutine(10f, () =>
        //{
        //    Destroy(bossScr.pumpkinsLv2[0]);
        //    Destroy(bossScr.pumpkinsLv2[1]);
        //    Destroy(bossScr.pumpkinsLv2[2]);
        //    Destroy(bossScr.pumpkinsLv2[3]);

        //    bossScr.pumpkinChildDeadCount++;
        //    bossScr.pumpkinChildDeadCount++;
        //    bossScr.pumpkinChildDeadCount++;
        //    bossScr.pumpkinChildDeadCount++;

        //}));

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
                                                                             //                                                                     //yield return new WaitWhile(条件);falseなら

        //////上　ななめ　攻撃        //Lv2
        //bossScr.pumpkinsLv2[2].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[3].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[4].GetComponent<RotModule>().enabled = true;

        //bossScr.pumpkinsLv2[2].GetComponent<PumpkinChildMove>().Initialize();
        //bossScr.pumpkinsLv2[3].GetComponent<PumpkinChildMove>().Initialize();
        //bossScr.pumpkinsLv2[4].GetComponent<PumpkinChildMove>().Initialize();

        //StartCoroutine(MyLib.LoopDelayCoroutineIf(stateTime < 22f, () =>
        //{
        //    if (bossScr.pumpkinsLv2[2] != null)
        //    {
        //        bossScr.pumpkinsLv2[2].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
        //        bossScr.pumpkinsLv2[3].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
        //        bossScr.pumpkinsLv2[4].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
        //    }

        //}));

        //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 13);



        //bossScr.pumpkinsLv2[5].GetComponent<RotModule>().enabled = true;
        //////ボスかぼちゃ　ピンボール        //Lv3

        //bossScr.pumpkinsLv2[5].GetComponent<PumpkinChildMove>().Initialize();

        //StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        //{
        //    if (bossScr.pumpkinsLv2[5] != null)
        //    {
        //        bossScr.pumpkinsLv2[5].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
        //    }

        //}));

    }

    public IEnumerator DEBUGAtkEnable()
    {

        //StartCoroutine(MyLib.DelayCoroutine(5f, () =>
        //{
        //    Destroy(bossScr.pumpkinsLv2[5]);
        //    bossScr.pumpkinChildDeadCount++;

        //}));

        bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        ////ボスかぼちゃ　ピンボール        //Lv3
        ///
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
        //GetComponent<pumpkinsLv2cr>().AtkInterval = GetComponent<pumpkinsLv2cr>().enemyData.AtkIntervalMax;
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        //foreach (var magazine in GetComponent<FlyScr>().baseMagazine)
        //    magazine.MagazineEnter();

        //GetComponent<PumpkinBossScr>().pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[1].GetComponent<RotModule>().enabled = true;
        //画面外に行き　当たり判定のある　敵を生成
        //右　左　攻撃
        //if (bossScr.pumpkinChildDeadCount == 6)//trueなら
            StartCoroutine(AtkEnable());
        //if (bossScr.pumpkinChildDeadCount == 0)//trueなら
        //  StartCoroutine(DEBUGAtkEnable());


        //if (bossScr.pumpkinChildDeadCount == 6)//trueなら
        //StartCoroutine(AtkEnableLv2());

        //StartCoroutine(Lv3(() =>
        //{
        //    bossScr.pumpkinsLv2[5].GetComponent<RotModule>().enabled = true;
        //    //ボスかぼちゃ　ピンボール
        //}));

        //StartCoroutine(MyLib.DelayCoroutineIfUntil(bossScr.pumpkinChildDeadCount == 5, () =>
        //{
        //    bossScr.pumpkinsLv2[5].GetComponent<RotModule>().enabled = true;
        //    //ボスかぼちゃ　ピンボール

        //}));

        //isAtkLv++;
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (bossScr.pumpkinChildDeadCount == 13)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

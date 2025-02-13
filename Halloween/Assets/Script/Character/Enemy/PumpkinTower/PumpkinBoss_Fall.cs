using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PumpkinBoss_Fall : StateChildBase
{

    PumpkinBossScr bossScr;

    const float fallStartTime = 0.3f;
    float fallTime = 0f;

    int pNo = 0;
    const int MAXPUMPKINCOUNT = 9;
    public IEnumerator DEBUGAtkEnable()
    {

        if (pNo >= MAXPUMPKINCOUNT)
            yield break;
        //StartCoroutine(MyLib.DelayCoroutine(5f, () =>
        //{
        //    //Destroy(bossScr.pumpkinsLv2[0]);
        //    bossScr.pumpkinChildDeadCount++;

        //}));
        foreach (GameObject go in bossScr.pumpkinsLv2)
        {
            go.GetComponent<RotModule>().enabled = true;

            go.GetComponent<PumpkinChildMove>().Initialize();
        }
        //bossScr.pumpkinsLv2[pNo].GetComponent<RotModule>().enabled = true;




        //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChildMove>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            if (bossScr.pumpkinsLv2[0] != null)
            {

                foreach (var go in bossScr.pumpkinsLv2)
                {
                    //go.GetComponent<RotModule>().enabled = true;

                    //go.GetComponent<PumpkinChildMove>().Initialize();

                    go.GetComponent<PumpkinChildMove>().MoveUpdateNoRot();

                }
                //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                //bossScr.pumpkinsLv2[1].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

        }));

        //pNo++;

        //yield return new WaitForSeconds(1f);
        //StartCoroutine(DEBUGAtkEnable());



        //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 16);

        //yield break;

    }

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
        bossScr = GetComponent<PumpkinBossScr>();
    }

    public override void OnEnter()
    {
        stateTime = 0f;


        bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        bossScr.pumpkinsLv2[0].GetComponent<PumpkinChildMove>().Initialize();

        //if (bossScr.pumpkinChildDeadCount == 6)//trueなら
        //   StartCoroutine(DEBUGAtkEnable());

        //foreach (GameObject go in bossScr.pumpkinsLv2)
        //{
        //    go.GetComponent<RotModule>().enabled = true;

        //    go.GetComponent<PumpkinChildMove>().Initialize();
        //}
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        fallTime += Time.deltaTime;

        //if (pNo >= MAXPUMPKINCOUNT)
        //
        bool isFallEnd = false;
        foreach (var f in bossScr.pumpkinsLv2)
            isFallEnd = f.GetComponent<PumpkinChildMove>().isFall;

        if (isFallEnd)
        {

            Debug.Log("LV2の全てのかぼちゃが落下した");
            foreach (var f in bossScr.pumpkinsLv2)
                f.GetComponent<PumpkinChildMove>().isAllFall=true;
            //イベント会話などの挿入
            return (int)PumpkinBossCtr.State.PumpkinBoss_AttackL2;


        }


        //if (pNo >= bossScr.pumpkinsLv2.Length-1)
        //    return StateType;

        //return StateType;
        //}

        //StartCoroutine(MyLib.DelayCoroutine(5f, () =>
        //{
        //    //Destroy(bossScr.pumpkinsLv2[0]);
        //    bossScr.pumpkinChildDeadCount++;

        //}));
        //foreach (GameObject go in bossScr.pumpkinsLv2)
        //{
        //    go.GetComponent<RotModule>().enabled = true;

        //    go.GetComponent<PumpkinChildMove>().Initialize();
        //}


        //bossScr.pumpkinsLv2[pNo].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChildMove>().Initialize();

        //StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        //{

        int stayNo = 0;
        for (int i = 0; i < pNo+1; i++)
        {


            if (bossScr.pumpkinsLv2[i] != null)
            {

                //foreach (var go in bossScr.pumpkinsLv2)
                //{
                //    //go.GetComponent<RotModule>().enabled = true;

                //    //go.GetComponent<PumpkinChildMove>().Initialize();

                //    go.GetComponent<PumpkinChildMove>().MoveUpdateNoRot();

                //}
                bossScr.pumpkinsLv2[i].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
                //bossScr.pumpkinsLv2[1].GetComponent<PumpkinChildMove>().MoveUpdateNoRot();
            }

            stayNo = i;
        }

        //}));


        //if(bossScr.pumpkinsLv2[stayNo].GetComponent<PumpkinChildMove>().isFall)
        if(fallTime> fallStartTime)
        {
            //配列の上限超えていたら
            if (pNo >= bossScr.pumpkinsLv2.Length - 1)
                return StateType;

            bossScr.pumpkinsLv2[stayNo+1].GetComponent<RotModule>().enabled = true;

            bossScr.pumpkinsLv2[stayNo+1].GetComponent<PumpkinChildMove>().Initialize();

            fallTime = 0;
            pNo++;

        }


        return (int)StateType;//PumpkinBossCtr.State.PumpkinBoss_Fall;

    }
}

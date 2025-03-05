using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_Fall : StateChildBase
{

    //PumpkinBossScr bossScr;

    const float fallStartTime = 0.3f;
    float fallTime = 0f;

    int pNo = 0;
    public int maxCountPumpkin = 9;

    public GameObject[] pumpkinsArray = new GameObject[] { };
    //public List<GameObject> pumpkinsList = new List<GameObject> { };
    //public IEnumerator DEBUGAtkEnable()
    //{

    //    if (pNo >= MAXPUMPKINCOUNT)d
    //        yield break;
    //    //StartCoroutine(MyLib.DelayCoroutine(5f, () =>
    //    //{
    //    //    //Destroy(bossScr.pumpkinsLv2[0]);
    //    //    bossScr.pumpkinChildDeadCount++;

    //    //}));
    //    foreach (GameObject go in bossScr.pumpkinsLv2)
    //    {
    //        //go.GetComponent<RotModule>().enabled = true;

    //        go.GetComponent<PumpkinChild>().Initialize();
    //    }
    //    //bossScr.pumpkinsLv2[pNo].GetComponent<RotModule>().enabled = true;




    //    //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChild>().Initialize();

    //    StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
    //    {
    //        if (bossScr.pumpkinsLv2[0] != null)
    //        {

    //            foreach (var go in bossScr.pumpkinsLv2)
    //            {
    //                //go.GetComponent<RotModule>().enabled = true;

    //                //go.GetComponent<PumpkinChild>().Initialize();

    //                go.GetComponent<PumpkinChild>().MoveUpdateNoRot();

    //            }
    //            //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChild>().MoveUpdateNoRot();
    //            //bossScr.pumpkinsLv2[1].GetComponent<PumpkinChild>().MoveUpdateNoRot();
    //        }

    //    }));

    //    //pNo++;

    //    //yield return new WaitForSeconds(1f);
    //    //StartCoroutine(DEBUGAtkEnable());



    //    //yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 16);

    //    //yield break;

    //}

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
        //bossScr = GetComponent<PumpkinBossScr>();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        fallTime = 0f;
        pNo = 0;

        //bossScr.pumpkinsLv2[0].GetComponent<RotModule>().enabled = true;
        pumpkinsArray[0].GetComponent<PumpkinChild>().Initialize();

        //if (bossScr.pumpkinChildDeadCount == 6)//trueなら
        //   StartCoroutine(DEBUGAtkEnable());

        //foreach (GameObject go in bossScr.pumpkinsLv2)
        //{
        //    go.GetComponent<RotModule>().enabled = true;

        //    go.GetComponent<PumpkinChild>().Initialize();
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
        foreach (var f in pumpkinsArray)
            isFallEnd = f.GetComponent<PumpkinChild>().isFall;

        if (isFallEnd)
        {

            //Debug.Log("LV2の全てのかぼちゃが落下した");
            foreach (var f in pumpkinsArray)
                f.GetComponent<PumpkinChild>().isAllFall=true;
            //イベント会話などの挿入


            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;


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

        //    go.GetComponent<PumpkinChild>().Initialize();
        //}


        //bossScr.pumpkinsLv2[pNo].GetComponent<RotModule>().enabled = true;
        //bossScr.pumpkinsLv2[pNo].GetComponent<PumpkinChild>().Initialize();

        //StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        //{

        int stayNo = 0;
        for (int i = 0; i < pNo+1; i++)
        {


            if (pumpkinsArray != null)
            {

                //foreach (var go in bossScr.pumpkinsLv2)
                //{
                //    //go.GetComponent<RotModule>().enabled = true;

                //    //go.GetComponent<PumpkinChild>().Initialize();

                //    go.GetComponent<PumpkinChild>().MoveUpdateNoRot();

                //}
                pumpkinsArray[i].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                //bossScr.pumpkinsLv2[1].GetComponent<PumpkinChild>().MoveUpdateNoRot();
            }

            stayNo = i;
        }

        //}));


        //if(bossScr.pumpkinsLv2[stayNo].GetComponent<PumpkinChild>().isFall)
        if(fallTime> fallStartTime)
        {
            //配列の上限超えていたら
            if (pNo >= pumpkinsArray.Length - 1)
                return StateType;

            //bossScr.pumpkinsLv2[stayNo+1].GetComponent<RotModule>().enabled = true;

            pumpkinsArray[stayNo+1].GetComponent<PumpkinChild>().Initialize();

            fallTime = 0;
            pNo++;

        }


        return (int)StateType;//PumpkinBossCtr.State.PumpkinBoss_Fall;

    }
}

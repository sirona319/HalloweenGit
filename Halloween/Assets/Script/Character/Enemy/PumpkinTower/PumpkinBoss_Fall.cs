using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_Fall : StateChildBase
{

    const float fallStartTime = 0.3f;
    float fallTime = 0f;

    int pNo = 0;
    public int maxCountPumpkin = 9;

    public GameObject[] pumpkinsArray;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        fallTime = 0f;
        pNo = 0;

        //回転速度の設定ができる
        pumpkinsArray[0].GetComponent<PumpkinChild>().Initialize();

    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        fallTime += Time.deltaTime;


        bool isFallEnd = false;
        foreach (var f in pumpkinsArray)
            isFallEnd = f.GetComponent<PumpkinChild>().isFall;

        if (isFallEnd)
        {

            foreach (var f in pumpkinsArray)
                f.GetComponent<PumpkinChild>().isAllFall=true;

            //イベント会話などの挿入もあり
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;


        }


        int stayNo = 0;
        for (int i = 0; i < pNo+1; i++)
        {


            if (pumpkinsArray != null)
                pumpkinsArray[i].GetComponent<PumpkinChild>().MoveUpdateNoRot();
            

            stayNo = i;
        }


        if(fallTime> fallStartTime)
        {
            //配列の上限超えていたら
            if (pNo >= pumpkinsArray.Length - 1)
                return StateType;

            //回転速度の設定ができる
            pumpkinsArray[stayNo+1].GetComponent<PumpkinChild>().Initialize();

            fallTime = 0;
            pNo++;

        }


        return (int)StateType;

    }
}

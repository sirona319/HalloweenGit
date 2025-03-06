using System.Collections;
using UnityEngine;
[DisallowMultipleComponent]
public class PumpkinBoss_AttackL3 : StateChildBase
{
    PumpkinBossScr bossScr;

    const int lastNo = 14;
    const int lastDesdCount = 30;

    //リストを作成して　入れたオブジェクトのアップデートを回すようにする？ (不具合があれば？コルーチン)
    public IEnumerator AtkEnable()
    {

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 16);//trueなら

        //Lv1

        bossScr.pumpkinsLv3[0].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[1].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[2].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[3].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0f, () =>
        {
            if (bossScr.pumpkinsLv3[0] != null)
            {
                bossScr.pumpkinsLv3[0].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[1].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[2].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[3].GetComponent<PumpkinChild>().MoveUpdateNoRot();
            }

        }));


        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == 20);//trueなら

        //Lv2

        bossScr.pumpkinsLv3[4].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[5].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[6].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[7].GetComponent<PumpkinChild>().Initialize();
        bossScr.pumpkinsLv3[8].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () => {
            if (bossScr.pumpkinsLv3[4] != null &&
            bossScr.pumpkinsLv3[5] != null &&
            bossScr.pumpkinsLv3[6] != null &&
            bossScr.pumpkinsLv3[7] != null &&
            bossScr.pumpkinsLv3[8] != null
            )
            {
                bossScr.pumpkinsLv3[4].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[5].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[6].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[7].GetComponent<PumpkinChild>().MoveUpdateNoRot();
                bossScr.pumpkinsLv3[8].GetComponent<PumpkinChild>().MoveUpdateNoRot();
            }

        }));

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount);
        //赤かぼちゃアニメーションなど



        var anim = bossScr.pumpkinsLv3[lastNo].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
                                        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().isShakeEnd);

        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().Initialize();

        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            if (bossScr.pumpkinsLv3[lastNo] != null)
            {
                bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().MoveUpdateNoRot();
            }

        }));

    }

    public IEnumerator DEBUGAtkEnable()
    {

        bossScr.pumpkinChildDeadCount = lastDesdCount;
        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount);
        //赤かぼちゃアニメーションなど

        var anim = bossScr.pumpkinsLv3[lastNo].GetComponent<Animator>();
        anim.SetBool("Shake", true);

        yield return new WaitUntil(() => bossScr.pumpkinChildDeadCount == lastDesdCount &&
                                        bossScr.pumpkinsLv3[lastNo].GetComponent<PumpkinChild>().isShakeEnd);

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

        //StartCoroutine(AtkEnable());
        StartCoroutine(DEBUGAtkEnable());
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (bossScr.pumpkinChildDeadCount == 31)
            return (int)PumpkinBossCtr.State.PumpkinBoss_Wait;

        return (int)StateType;
    }
}

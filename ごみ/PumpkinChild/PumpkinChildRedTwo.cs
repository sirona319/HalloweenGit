using DG.Tweening;
using UnityEngine;

public class PumpkinChildRedTwo : PumpkinChild
{
    //赤かぼちゃ用　継承する？
    public bool isShakeEnd = false;

    [SerializeField] GameObject fallPtL;
    [SerializeField] GameObject fallPtR;

    [SerializeField] Transform fallPointRed;
    //

    public override void Spawn()
    {
        var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
        var obj2 = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);

        var eMove = obj.GetComponent<PumpkinScr>().move;
        //eMove.Initialize();

        //if (obj.GetComponent<NoiseEnablePumpkin>() != null)
        //    obj.GetComponent<NoiseEnablePumpkin>().noiseTiming = noiseTiming;

        var eMove2 = obj2.GetComponent<PumpkinScr>().move;
        //eMove2.Initialize();
        // (obj2.GetComponent<NoiseEnablePumpkin>() != null)
      //      obj2.GetComponent<NoiseEnablePumpkin>().noiseTiming = noiseTiming;

        //if (eBase.GetComponent<StraightForceMove>() != null)
        //{
        //eMove.GetComponent<StraightForceMove>().speed = setPointSpeed;
        //eMove2.GetComponent<StraightForceMove>().speed = setPointSpeed;
        //eMove.GetComponent<StraightForceMove>().SetTarget(spPointLists[0]);
        //eMove2.GetComponent<StraightForceMove>().SetTarget(spPointLists[1]);
        //}

        gameObject.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;

        isMoveEnd = true;
    }


    #region　アニメーションイベント
    public void EventShake()
    {
        const float duration = 1f;
        transform.DOMove(fallPointRed.position, duration);

        StartCoroutine(MyLib.DelayCoroutine(duration, () =>
        {

            fallPtL.SetActive(false);
            fallPtR.SetActive(false);

            GetComponent<Animator>().enabled = false;

            //揺らす長さ
            const float shakeLength = 0.15f;
            //揺らす力
            const float power = 0.3f;

            StartCoroutine(MyLib.DoShake(shakeLength, power, transform));

            StartCoroutine(MyLib.DelayCoroutine(shakeLength + 0.5f, () =>
            {
                isShakeEnd = true;



            }));


        }));

    }

    public void EventPtActive()
    {
        fallPtL.SetActive(true);
        fallPtR.SetActive(true);

    }

    #endregion
}

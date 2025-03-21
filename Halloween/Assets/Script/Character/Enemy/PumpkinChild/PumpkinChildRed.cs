﻿using DG.Tweening;
using UnityEngine;

public class PumpkinChildRed : PumpkinChild
{
    //赤かぼちゃ用　継承する？
    public bool isShakeEnd = false;

    [SerializeField] GameObject fallPtL;
    [SerializeField] GameObject fallPtR;

    [SerializeField] Transform fallPointRed;

    public override void Spawn()
    {
        var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
        var eBase = obj.GetComponent<EnemyBase>().baseMove[0];
        eBase.Initialize();
        eBase.GetComponent<PumpkinScr>().isNoise = isNoise;
        eBase.GetComponent<PumpkinScr>().noiseTiming = noiseTiming;


        if (eBase.GetComponent<StraightForceMove>() != null)
        {
            eBase.GetComponent<StraightForceMove>().SetTarget(movePointLists[0]);
        }




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

﻿using DG.Tweening;
using UnityEngine;

public class AnimEventShakeScr : MonoBehaviour
{
    #region　アニメーションイベント
    //赤かぼちゃ用　継承する？
    public bool isShakeEnd = false;

    [SerializeField] GameObject fallPtL;
    [SerializeField] GameObject fallPtR;

    [SerializeField] Transform fallPointRed;

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

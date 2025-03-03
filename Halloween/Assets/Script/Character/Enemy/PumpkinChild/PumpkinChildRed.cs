using UnityEngine;

public class PumpkinChildRed : PumpkinChild
{

    //赤かぼちゃ用　継承する？
    //public bool isShakeEnd = false;

    [SerializeField] GameObject fallPtL;
    [SerializeField] GameObject fallPtR;
    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //#region　アニメーションイベント
    //public void EventShake()
    //{
    //    fallPtL.SetActive(false);
    //    fallPtR.SetActive(false);

    //    GetComponent<Animator>().enabled = false;

    //    //揺らす長さ
    //    const float shakeLength = 0.15f;
    //    //揺らす力
    //    const float power = 0.3f;

    //    StartCoroutine(MyLib.DoShake(shakeLength, power, transform));

    //    StartCoroutine(MyLib.DelayCoroutine(shakeLength + 0.5f, () =>
    //    {
    //        isShakeEnd = true;
    //    }));
    //}

    //public void EventPtActive()
    //{
    //    fallPtL.SetActive(true);
    //    fallPtR.SetActive(true);

    //}

    //#endregion
}

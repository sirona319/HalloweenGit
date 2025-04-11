using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinChild : MonoBehaviour
{
    //[SerializeField] protected bool isNoise;
    [SerializeField] protected float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる

    public bool isFall=false;
    public bool isAllFall = false;

    [SerializeField] protected GameObject spawnObj;
    //[SerializeField] public Transform[] spawnObjMovePoints;
    [SerializeField] public List<Transform> spPointLists=new();//生成したオブジェクトに設定する移動座標
    [SerializeField] protected float setPointSpeed = 7f;
    [SerializeField] float spdSetTiming;


    [SerializeField] public Transform[] moveTrans;//移動座標
    [SerializeField] float speed = 5f;
    const float ENDMOVELEN = 0.2f;
    protected int targetNo = 0;
    protected bool isMoveEnd = false;


    public void Initialize()
    {
        GetComponent<RotModule>().enabled = true;
    }

    public void MoveUpdateNoRot()
    {
        if (isMoveEnd) return;

        if (isFall)
        {
            if(isAllFall)
                PumpkinMove();
            
            //////ENDMOVELENのような ROTSTARTLENを作成する？　挙動が不自然なため
            //transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, 5f);
            return;
        }

        //PumpkinMove();
    }

    public void MoveUpdateNoRotisFall()
    {
        if (isMoveEnd) return;

        PumpkinMove();


    }

    void PumpkinMove()
    {
        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len > ENDMOVELEN)
        {
            Vector3 direction = moveTrans[targetNo].position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            return;
        }


        if (targetNo == 0)
        {
            isFall = true;
            GetComponent<RotModule>().enabled = false;
        }


        if (targetNo == moveTrans.Length - 1)
        {
            Spawn();
            isMoveEnd = true;

        }
        else
        {
            targetNo++;

        }

    }

    public virtual void Spawn()
    {
        var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
        var eBase = obj.GetComponent<PumpkinScr>().move;
        //eBase.Initialize();
        //if (obj.GetComponent<NoiseEnablePumpkin>() != null)
        //    obj.GetComponent<NoiseEnablePumpkin>().noiseTiming = noiseTiming;



        //if (eBase.GetComponent<SPointMovePumpkin>() != null)
        //{
        //    eBase.GetComponent<SPointMovePumpkin>().SetSpeed(setPointSpeed, spdSetTiming);
        //    eBase.GetComponent<SPointMovePumpkin>().SetTarget(spPointLists);//spawnObjMovePoint[0].position;
        //}

        //if(this.GetComponent<LineRenderModule>()!=null)
        //{
        //    this.GetComponent<LineRenderModule>().LineCreate(transform);
        //    this.GetComponent<LineRenderModule>().LineDraw();

        //    StartCoroutine(DelayOff(obj));

        //}


        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }

    //public IEnumerator DelayOff(GameObject go)
    //{
    //    const float offLen = 0.2f;
    //    var v = spPointLists[spPointLists.Count - 1].position;

    //    yield return new WaitUntil(() => Vector3.Distance(v, go.transform.position)< offLen);//trueなら

    //    this.GetComponent<LineRenderModule>().SetOffTimer(0f);
    //    gameObject.SetActive(false);
    //}

    //#region　アニメーションイベント
    //public void EventShake()
    //{
    //    const float duration = 1f;
    //    transform.DOMove(fallPointRed.position, duration);

    //    StartCoroutine(MyLib.DelayCoroutine(duration, () =>
    //    {

    //        fallPtL.SetActive(false);
    //        fallPtR.SetActive(false);

    //        GetComponent<Animator>().enabled = false;

    //        //揺らす長さ
    //        const float shakeLength = 0.15f;
    //        //揺らす力
    //        const float power = 0.3f;

    //        StartCoroutine(MyLib.DoShake(shakeLength, power, transform));

    //        StartCoroutine(MyLib.DelayCoroutine(shakeLength + 0.5f, () =>
    //        {
    //            isShakeEnd = true;
    //        }));


    //    }));

    //}

    //public void EventPtActive()
    //{
    //    fallPtL.SetActive(true);
    //    fallPtR.SetActive(true);

    //}

    //#endregion

}

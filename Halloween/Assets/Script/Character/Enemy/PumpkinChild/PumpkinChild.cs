using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinChild : MonoBehaviour
{
    [SerializeField] protected bool isNoise;
    [SerializeField] protected float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる

    public bool isFall=false;
    public bool isAllFall = false;

    [SerializeField] protected GameObject spawnObj;

    [SerializeField] public Transform[] moveTrans;

    //[SerializeField] public Transform[] spawnObjMovePoints;
    [SerializeField] public List<Transform> movePointLists=new();

    [HideInInspector] float speed = 5f;

    const float ENDMOVELEN = 0.2f;
    protected int targetNo = 0;
    protected bool isMoveEnd = false;

    [SerializeField] protected float sPointSpeed=7f;


    [SerializeField] float spdSetTiming;
    ////赤かぼちゃ用　継承する？
    //public bool isShakeEnd = false;

    //[SerializeField] GameObject fallPtL;
    //[SerializeField] GameObject fallPtR;

    //[SerializeField] Transform fallPointRed;
    ////

    public void Initialize()
    {
        GetComponent<RotModule>().enabled = true;
    }

    public void MoveEnter()
    {

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

        PumpkinMove();
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

        }
        else
        {
            targetNo++;

        }

    }

    public virtual void Spawn()
    {
        var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
        var eBase = obj.GetComponent<EnemyBase>().baseMove[0];
        eBase.Initialize();
        eBase.GetComponent<PumpkinScr>().isNoise = isNoise;
        eBase.GetComponent<PumpkinScr>().noiseTiming = noiseTiming;



        if (eBase.GetComponent<StraightPointMove>() != null)
        {
            eBase.GetComponent<StraightPointMove>().SetSpeed(sPointSpeed, spdSetTiming);
            eBase.GetComponent<StraightPointMove>().SetTarget(movePointLists);//spawnObjMovePoint[0].position;
        }

        if(this.GetComponent<LineRenderModule>()!=null)
        {
            this.GetComponent<LineRenderModule>().LineCreate(transform);
            this.GetComponent<LineRenderModule>().LineDraw();

            StartCoroutine(DelayOff(obj));
            //{
            //    //yield return new WaitUntil(() =>0 == 0);//trueなら
            //    gameObject.SetActive(false);
            //    //Destroy(gameObject);　エラー

            //}));
            //Destroy(gameObject,10f);
        }


        //}


        //if (eBase.GetComponent<StraightForceMove>() != null)
        //{
        //    eBase.GetComponent<StraightForceMove>().SetTarget(movePointLists[0]);
        //}
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;

        isMoveEnd = true;
    }

    public IEnumerator DelayOff(GameObject go)
    {
        const float offLen = 0.3f;
        var v = movePointLists[movePointLists.Count - 1].position;
        //yield return new WaitForSeconds(seconds);
        yield return new WaitUntil(() => Vector3.Distance(v, go.transform.position)< offLen);//trueなら

        this.GetComponent<LineRenderModule>().SetOffTimer(0f);
        gameObject.SetActive(false);
    }

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

using System.Collections.Generic;
using UnityEngine;

public class PumpkinChild : MonoBehaviour
{
    [SerializeField] bool isNoise;
    [SerializeField] float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる
    //[SerializeField] Transform[] warpPositions;
    //public int childNo = 0;

    public bool isFall=false;
    public bool isAllFall = false;

    [SerializeField] GameObject spawnObj;

    [SerializeField] public Transform[] moveTrans;

    [SerializeField] public Transform[] spawnObjMovePoints;
    [SerializeField] public  List<Transform> spawnObjMovePointsList;

    [HideInInspector] float speed = 5f;
    const float ENDMOVELEN = 0.2f;
    int targetNo = 0;
    bool isMoveEnd = false;


    //赤かぼちゃ用　継承する？
    public bool isShakeEnd = false;

    [SerializeField] GameObject fallPtL;
    [SerializeField] GameObject fallPtR;
    //

    public void movePointSet(Transform[] ts)
    {
        moveTrans = ts;

        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    }

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
            
            ////ENDMOVELENのような ROTSTARTLENを作成する？　挙動が不自然なため
            /////transform.GetChild(0).rotation = MyLib.GetAngleRotationFuncs((transform.GetChild(0).position + Vector3.up), transform.GetChild(0), 5f);
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
            //ここに処理を追加できるようにしたい
            //IsPoint = true;
            var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
            var eBase = obj.GetComponent<EnemyBase>().baseMove[0];
            eBase.Initialize();
            eBase.GetComponent<PumpkinScr>().isNoise = isNoise;
            eBase.GetComponent<PumpkinScr>().noiseTiming = noiseTiming;
            //eBase.GetComponent<PumpkinScr>().warpPositions = warpPositions;



            if (eBase.GetComponent<StraightPointMove>() != null)
                eBase.GetComponent<StraightPointMove>().SetTarget(spawnObjMovePoints);//spawnObjMovePoint[0].position;


            if (eBase.GetComponent<StraightForceMove>() != null)
                eBase.GetComponent<StraightForceMove>().SetTarget(spawnObjMovePoints[0]);//spawnObjMovePoint[0].position;



            gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;

            isMoveEnd = true;
        }
        else
        {
            targetNo++;

        }

    }

    #region　アニメーションイベント
    public void EventShake()
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
    }

    public void EventPtActive()
    {
        fallPtL.SetActive(true);
        fallPtR.SetActive(true);

    }

    #endregion

}

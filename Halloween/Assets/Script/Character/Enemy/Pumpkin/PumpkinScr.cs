using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PumpkinScr : EnemyBase
{
    public bool isBoss = false;
    public SpriteRenderer sprite;
    //public float AtkInterval = 1;


    //ノイズ　瞬間移動
    public bool isNoise;
    const float noiseTimingDefault = 5f;
    public float noiseTiming = 5f;//ランダムで数字を足して　瞬間移動させる
    float noiseLength = 0.4f;
    [SerializeField] float noiseTime = 0f;


    public Transform[] warpPositions;
    [SerializeField] float randTime = 0f;
    float randTimeMax = 2f;
    float randTimeMin = 0.5f;
    const float speed = 12f;

    Transform pTrans;
    StraightForceMove sMove;

    //
    void Start()
    {
        base.StartInit();
        base.Init();

        stateController.Initialize((int)FlyCtr.State.Fly_Wait);

        randTime = Random.Range(randTimeMin, randTimeMax);
        pTrans = GameObject.FindWithTag("Player").transform;
        sMove = baseMove[0].GetComponent<StraightForceMove>();

    }

    void Update()
    {
        AttackTimeUpdate();

        //if (transform.position.z != 0f)
        //{
        //    var tr = transform.position;
        //    tr.z = 0f;
        //    transform.position = tr;
        //}

        stateController.UpdateSequence();

        //ResetPos2DZ();
    }

    void ResetPos2DZ()
    {
        if (transform.position.z == 0f)
            return;

        var tr = transform.position;
        tr.z = 0f;
        transform.position = tr;
        
    }

    //private void FixedUpdate()
    //{
    //    if(transform.position.z!=0f)
    //    {
    //        var tr = transform.position;
    //        tr.z = 0f;
    //        transform.position = tr;
    //    }
    //}


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        //AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int ReturnStateType(int stateType)
    {
        //if (AtkInterval <= 0)
        //    return (int)FlyCtr.State.Fly_Attack;
        //else 
        if (IsMove)
            return (int)FlyCtr.State.Fly_Move;

        else
            return (int)FlyCtr.State.Fly_Wait;

    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Test");
    //    if (!other.gameObject.CompareTag("Player"))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.gameObject.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}

    //private void OnCollisionEnter2D(Collider2D other)
    //{

    //    if (!other.transform.CompareTag("Player"))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}



    //public bool idRend = false;


    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>
    private void OnBecameVisible()
    {
        //GetComponent<NoiseEnable>().enabled = true;

        //idRend = true;
        //Debug.Log("OnBecameVisible");
        //this.GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// Rendererがカメラから見えなくなると呼び出される
    /// </summary>
    private void OnBecameInvisible()
    {
        //GetComponent<NoiseEnable>().enabled = false;

        //Debug.Log("OnBecameInvisible");
        //this.GetComponent<Renderer>().material.color = Color.blue;
    }

    // <summary>
    // カメラに写っている間常に呼ばれる SpriteRendererの関係で不具合が起こる
    // </summary>
    private void OnWillRenderObject()
    {
        if (!isNoise) return;
        if (noiseTime >= (noiseTiming + randTime) + noiseLength) return;

        noiseTime += Time.deltaTime;


        if (noiseTime > noiseTiming + randTime && GetComponent<NoiseEnable>().enabled == false)
        {
            WorpPositionSelect();

            //ノイズを有効に
            GetComponent<NoiseEnable>().enabled = true;

        }

        if (noiseTime >= (noiseTiming + randTime) + noiseLength && GetComponent<NoiseEnable>().enabled == true)
        {
            GetComponent<NoiseEnable>().enabled = false;

            //赤かぼちゃのみ
            if (transform.name.Contains("Red"))
            {
                randTime = Random.Range(randTimeMin, randTimeMax + 1);

                noiseTiming += noiseTimingDefault;
            }
            //乱数の再計算　大きめにする？
            //タイミングの加算
        }


#if UNITY_EDITOR

        //if (Camera.current.name != "Main Camera" && Camera.current.name != "Preview Camera")
            //Debug.Log("OnWillRenderOject");
        //Camera.current.transform;
#endif
    }



    void WorpPositionSelect()
    {
        List<Vector2> warpList = new List<Vector2>();

        foreach(var i in warpPositions)
        {
            warpList.Add(i.position);
        }

        while (true)
        {

            //ランダムで座標を決定
            var randInt = Random.Range(0, warpList.Count);

            //座標移動させる　カメラ内かどうか判定
            if (MyLib.IsVisibleByCamera(warpList[randInt]))
            {

                sMove.rb.position= warpList[randInt];
                var dir = (Vector2)pTrans.position - (Vector2)warpList[randInt];

                sMove.rb.linearVelocity = dir.normalized * speed;

                Debug.Log("ワープ");
                break;
            }
            else
            {
                warpList.RemoveAt(randInt);
                Debug.Log("ワープに失敗");
                //return false;
            }
        }
    }



}

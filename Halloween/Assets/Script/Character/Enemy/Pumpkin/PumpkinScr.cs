using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PumpkinScr : EnemyBase
{
    [SerializeField] EnemyDamage eDamage;
    public BaseMove move;

    public bool isMove = true;

    public bool isBoss = false;

    //public SpriteRenderer sprite;

    ////ノイズ　瞬間移動
    //public bool isNoise;
    //public float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる
    //float noiseLength = 0.5f;
    //[SerializeField] float noiseTime = 0f;

    //GameObject[] warpPositions;
    //[SerializeField] float randTime = 0f;
    //float randTimeMax = 2f;
    //float randTimeMin = 0.5f;


    //Transform pTrans;

    ////赤かぼちゃのみ
    //const float noiseTimingDefaultRed = 8f;
    ////

    public bool ReturnStateTypeDead()
    {
        if (isDead) return true;

        return false;
    }

    void Start()
    {
        move.Initialize();

        stateController.Initialize((int)PumpkinCtr.State.Pumpkin_Wait);

        //randTime = Random.Range(randTimeMin, randTimeMax);
        //pTrans = GameObject.FindWithTag(TagName.Player).transform;

        //warpPositions = GameObject.FindGameObjectsWithTag("PumpkinWorp");

    }

    void Update()
    {

        stateController.UpdateSequence();

    }

    public int ReturnStateType(int stateType)
    {

        if (isMove)
            return (int)PumpkinCtr.State.Pumpkin_Move;

        else
            return (int)PumpkinCtr.State.Pumpkin_Wait;

    }

    public int DamageCheck()
    {

        if (ReturnStateTypeDead())
            return (int)PumpkinCtr.State.Pumpkin_Dead;
        else
            return (int)PumpkinCtr.State.Pumpkin_Damage;

    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Test");
    //    if (!other.gameObject.CompareTag(TagName.Player))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.gameObject.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}

    //private void OnCollisionEnter2D(Collider2D other)
    //{

    //    if (!other.transform.CompareTag(TagName.Player))
    //        return;

    //    Debug.Log("ColPlayer");

    //    //プレイヤーへのダメージ処理
    //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);


    //}



    //public bool idRend = false;


   



}

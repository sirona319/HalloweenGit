using System.Collections.Generic;
using System;
using UnityEngine;
using static EnemyData;

[DisallowMultipleComponent]
public class PumpkinBossScr : MonoBehaviour, IHaveText
{
    #region ステートコントローラー
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    [NonSerialized] public bool IsDead = false;
    [NonSerialized] public bool IsDamage = false;
    [NonSerialized] public bool IsAttack = true;
    [NonSerialized] public bool IsMove = true;


    public bool startBattle = false;

    public int pumpkinChildDeadCount = 0;

    [SerializeField] float rotSpeedPumpkin1 = 0;
    [SerializeField] float rotSpeedPumpkin2 = 0;
    [SerializeField] float rotSpeedPumpkin3 = 0;
    public GameObject[] pumpkins; //主に攻撃に使用
    public GameObject[] pumpkinsLv2;
    public GameObject[] pumpkinsLv3;

    //public GameObject[][] pumpkinsDEBUG;
    //SerializeField] SerializedDictionary<PumpkinChild, bool> pumpkinDicLv3;

    public TimelineControl[] timelineTexts;
    int timelineNo = 0;

    public EnemyDamage eDamage;
    public void TextReadPlus()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        timelineNo++;
    }

    public void BattleEnd()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();

    }

    public void BattleStart(bool f)
    {
        startBattle = f;
    }

    void Start()
    {
        foreach (var go in pumpkins)
        {
            go.GetComponent<RotModule>().speed = rotSpeedPumpkin1;
        }
        foreach (var go in pumpkinsLv2)
        {
            go.GetComponent<RotModule>().speed = rotSpeedPumpkin2;
        }
        foreach (var go in pumpkinsLv3)
        {
            go.GetComponent<RotModule>().speed = rotSpeedPumpkin3;
        }

        stateController.Initialize((int)PumpkinBossCtr.State.PumpkinBoss_Wait);

    }

    protected virtual void Init()
    {
        ////スクリプタルオブジェクトのデータを取得
        //enemyData = EnemyManager.I.GetEnemyData(findName);

        ////enemyDataのnullチェック
        //if (enemyData == null)
        //    throw new System.Exception(gameObject.name + "　Data null");

        //ステータスの初期化
       // Hp = enemyData.HpMax;


        //baseMagazine初期化
        //for (int i = 0; i < (int)enemyData.attackType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

        //    if (typeClass != null)
        //        baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

        //}

        //foreach (var magazine in baseMagazine)
        //    magazine.Initialize();


        //baseMove初期化
        //for (int i = 0; i < (int)enemyData.moveType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(enemyData.moveType[i].ToString());

        //    if (typeClass != null)
        //        baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));

        //}

        //foreach (var move in baseMove)
        //    move.Initialize();




        //enemyData.movePointsSet = movePointsInit;

    }


    void Update()
    {

        stateController.UpdateSequence();

    }

}

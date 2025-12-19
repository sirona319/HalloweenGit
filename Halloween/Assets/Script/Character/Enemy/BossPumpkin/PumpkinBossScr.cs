using System;
using UnityEngine;
//using static EnemyData;

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

    [NonSerialized] public bool isDead = false;
    [NonSerialized] public bool isDamage = false;
    [NonSerialized] public bool isAttack = true;
    [NonSerialized] public bool isMove = true;


    public bool startBattle = false;

    public int pumpkinChildDeadCount = 0;// 6  16
    public bool testLv2 = false;
    public bool testLv3 = false;

    //[SerializeField] float rotSpeedPumpkin1 = 0;
    //[SerializeField] float rotSpeedPumpkin2 = 0;
    //[SerializeField] float rotSpeedPumpkin3 = 0;
    public GameObject[] pumpkins; //主に攻撃に使用
    public GameObject[] pumpkinsLv2;
    public GameObject[] pumpkinsLv3;

    //public GameObject[][] pumpkinsDEBUG;
    //SerializeField] SerializedDictionary<PumpkinChild, bool> pumpkinDicLv3;

    public TimelineControl[] timelineTexts;
    int timelineNo = 0;

    //public EnemyDamage eDamage;

    //public bool isDEBUG=true;
    public void TextReadPlus()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        timelineNo++;
    }
    public void BattleEnd()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();
        startBattle = false;

    }
    #region シグナル

    public void SignalBattleState(bool f)
    {
        startBattle = f;
    }

    #endregion

    void Start()
    {
        if(testLv2)
            pumpkinChildDeadCount= 6;
        if (testLv3)
            pumpkinChildDeadCount= 16;

        //foreach (var go in pumpkins)
        //{
        //    go.GetComponent<RotModule>().speed = rotSpeedPumpkin1;
        //}
        //foreach (var go in pumpkinsLv2)
        //{
        //    go.GetComponent<RotModule>().speed = rotSpeedPumpkin2;
        //}
        //foreach (var go in pumpkinsLv3)
        //{
        //    go.GetComponent<RotModule>().speed = rotSpeedPumpkin3;
        //}

        stateController.Initialize((int)PumpkinBossCtr.State.PumpkinBoss_Wait);

    }

    void Update()
    {

        stateController.UpdateSequence();

    }

}

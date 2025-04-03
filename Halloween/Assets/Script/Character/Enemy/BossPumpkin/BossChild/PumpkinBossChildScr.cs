using System.Collections.Generic;
using UnityEngine;

public class PumpkinBossChildScr : EnemyBase
{
    //public BaseMove spawnMove;
    //public BaseMove fallMove;
    public bool isFallMove = false;
    public bool isSpawnMove = false;

    public bool isFallEnd = false;
    public bool isAllFallEnd = false;

    //[SerializeField] protected float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる


    //[SerializeField] protected GameObject spawnObj;
    ////[SerializeField] public Transform[] spawnObjMovePoints;
    //[SerializeField] public List<Transform> movePointLists = new();//生成したオブジェクトに設定する移動座標
    //[SerializeField] protected float setPointSpeed = 7f;
    //[SerializeField] float spdSetTiming;

    void Start()
    {
        stateController = GetComponent<PumpkinBossChildCtr>();

        //spawnMove=GetComponent<SpawnPumpkinChild>();
        //fallMove = GetComponent<FallPumpkinChild>();
        stateController.Initialize((int)PumpkinBossCtr.State.PumpkinBoss_Wait);
    }

    void Update()
    {
        stateController.UpdateSequence();
    }

    public int PumpkinStateType(int stateType)
    {
        if (isFallMove)
            return (int)PumpkinBossChildCtr.State.PumpkinChild_Fall;

        else if (isSpawnMove)
            return (int)PumpkinBossChildCtr.State.PumpkinChild_Move;

        else
            return (int)PumpkinBossChildCtr.State.PumpkinChild_Wait;

    }

}

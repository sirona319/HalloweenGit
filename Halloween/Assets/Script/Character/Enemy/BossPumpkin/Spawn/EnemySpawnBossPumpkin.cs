using System.Collections;
using UnityEngine;

public class EnemySpawnBossPumpkin : BaseSpawn
{

    [SerializeField] SpawnWaveDataPrefab[] spawnData;

    [SerializeField] GameObject saveGo;

    EnemyMgr EnemyM;

    [SerializeField] string bossColTag;

    void Start()
    {
        EnemyM = GameObject.FindGameObjectWithTag("EnemyM").GetComponent<EnemyMgr>();

        Spawn(0);
    }


    public void Spawn(int No)
    {
        EnemyM.CountUp(spawnData[No].LoadState.Length);

        StartCoroutine(DelaySpawnWave(
            spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

            spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

            spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
                                                                  //spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
            ));
    }


    public IEnumerator DelaySpawnWave(float seconds, GameObject loadState, Transform spawnTrans/*, Transform[] movePoint*/)
    {
        yield return new WaitForSeconds(seconds);

        saveGo = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);

    }

    public override void DeadNotice()
    {
        GameObject.FindGameObjectWithTag(bossColTag).GetComponent<BossCollisionTrigger>().BossCollisionOffLosePlayer();
        //GameObject.FindGameObjectWithTag("BossPumpkin").GetComponent<IHaveText>().TextReset();
        GameObject.FindGameObjectWithTag("PumpkinText").transform.GetChild(0).GetComponent<TimelineControl>().FlgReset();
        MyLib.DebugInfo(gameObject);
        //敵全部を破棄　生成
        //Destroy(saveGo);
        EnemyM.EnemyClearAll();

        //EnemyMgr.I.EnemyClearAll();
        Spawn(0);

        Debug.Log("BossDead");

        //timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();
        //startBattle = false;
    }


}

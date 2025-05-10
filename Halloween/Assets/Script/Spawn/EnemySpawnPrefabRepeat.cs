using System.Collections;
using UnityEngine;

public class EnemySpawnPrefabRepeat : BaseSpawn
{
    [SerializeField] float notifyTime = 0f;
    [SerializeField] float objDeadTime = 0f;

    [SerializeField] SpawnWaveDataPrefab[] spawnData;


    void Start()
    {
        //最初のスポーン　エリアか時間で生成するようにする？
        Spawn(0);
    }

    public override void Spawn(int No)
    {

        //if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
        GameSceneControl.I.CountUp(spawnData[No].LoadState.Length);

        //1回目以降
        //while (true)
        //{
        StartCoroutine(DelaySpawnWave(
            spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

            spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

            spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
                                                                  //spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
            ));


        // break;
        //spawnData[No].enemyCount++;
        //if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
        //    break;

        //}

    }

    public void SpawnWaveTime(int No)
    {
        StartCoroutine(MyLib.DelayCoroutine(notifyTime, () =>
        {
            Spawn(No);
            Debug.Log(gameObject.name+"スポーン");
        }));

    }

    public IEnumerator DelaySpawnWave(float seconds, GameObject loadState, Transform spawnTrans)
    {
        yield return new WaitForSeconds(seconds);

        var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);

        var notify = obj.AddComponent<NotifyDead>();
        notify.spawnObj = gameObject;
        var tDes = obj.AddComponent<TimeDestroy>();
        tDes.deadTime = objDeadTime;
        //notify.spawnTime = notifyTime;
    }

}

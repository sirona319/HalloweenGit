using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class EnemySpawnWavePrefab : MonoBehaviour
{
    //[SerializeField] JerryBuilder jerryBuilder;

    public SpawnWaveDataPrefab[] spawnData;

    int CountIndex = 0;

    //[SerializeField] GameObject trailSe;
    public void UpdateCount()
    {
        spawnData[CountIndex].enemyCount--;

        if (spawnData[CountIndex].enemyCount <= 0)
        {
            CountIndex++;
            if (CountIndex == spawnData.Length)
                return;

            EnemysWaveStart(CountIndex);

        }
    }

    void Start()
    {
        EnemysWaveStart(0);

    }

    void EnemysWaveStart(int idx)
    {

        SpawnWave(idx);
    }

    void SpawnWave(int No)
    {

        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawnData[No].LoadState.Length;



        //1回目以降
        while (true)
        {
            DelaySpawnAsyncWave
                (spawnData[No].spawnTime[spawnData[No].enemyCount] /** spawnData[No].enemyCount + 1*/,//float型　生成時間

                spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類


                spawnData[No].spawnLocations[spawnData[No].enemyCount],//生成座標
                spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
                ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }


    void Update()
    {
    }

    public void ResetEnemySpawn()
    {

    }

    public async UniTask DelaySpawnAsyncWave(float seconds, GameObject loadState, Transform spawnTrans, Transform[] movePoint)
    {
        await UniTask.WaitForSeconds(seconds);

        var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);


        SelectCreateMoveJerry(obj.GetComponent<EnemyBase>().baseMove[0].GetType().FullName, movePoint, obj);

    }

    //ムーブ設定
    void SelectCreateMoveJerry(string moveType, Transform[] movePoint, GameObject go)
    {
        switch (moveType)
        {
            case "PlayerAttackPointMove":

                go.GetComponent<PlayerAttackPointMove>().Initialize();

                go.GetComponent<PlayerAttackPointMove>().point.movePointSet(movePoint);

                go.GetComponent<PlayerAttackPointMove>().playerAttack.TargetSet(GameObject.FindGameObjectWithTag("Player").transform);

                break;

           
            default:
                go.GetComponent<EnemyBase>().baseMove[0].Initialize();

                //Debug.Log("MoveTypeDEFAULT");
                break;
        }

    }

}

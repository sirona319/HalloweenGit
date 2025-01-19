using UnityEngine;
//using System.Linq;
using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine.AddressableAssets;

public class EnemyManager : Singleton<EnemyManager>
{
    EnemySetting enemySetting;

    //public EnemyBase aa;
    private async UniTask UniStart()
    {
        enemySetting = await Addressables.
               LoadAssetAsync<EnemySetting>("Assets/EnemySetting.asset");

        //スライムのデータを取得
        //var slimeData = enemySetting.DataList.
        //                FirstOrDefault(enemy => enemy.Id == "JerryNormal");
        //Debug.Log($"ID：{slimeData.Id}");



    }

    private async void Start()
    {
        await UniStart();
        //enemySetting = Resources.Load<EnemySetting>("EnemySetting");
    }

    public EnemyData GetEnemyData(string name)
    {
        //enemySetting = Resources.Load<EnemySetting>("EnemySetting");

        var data = enemySetting.DataList.
              FirstOrDefault(enemy => enemy.Id == name);

        return data;
    }
}

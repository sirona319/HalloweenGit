using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (saveGo.CompareTag(TagName.EnemyBoss))
    //    //{
    //    //    //敵全部を破棄　生成？
    //    //    //破棄と生成
    //    //    Destroy(saveGo);
    //    //    Spawn(0);

    //    //}
    //}

    public void EnemyClearAll()
    {
        var enemys = GameObject.FindGameObjectsWithTag(TagName.Enemy);

        foreach (var e in enemys)
        {
            Destroy(e);
        }

        var enemysB = GameObject.FindGameObjectsWithTag(TagName.EnemyBoss);

        foreach (var e in enemysB)
        {
            Destroy(e);
        }
    }
}

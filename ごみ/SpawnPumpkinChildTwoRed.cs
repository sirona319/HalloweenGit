using UnityEngine;

public class SpawnPumpkinChildTwoRed : StraightPointMove
{
    [SerializeField] protected GameObject spawnObj;

    public override void MoveEnter()
    {
        //base.MoveEnter();
        GetComponent<RotModule>().enabled = true;
        direction = (movePointLists[targetNo].position - transform.position).normalized;
    }

    public override void MoveExit()
    {

        GetComponent<RotModule>().enabled = false;
    }

    public override void MoveUpdate()
    {

        ////指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;


        float len = Vector3.Distance(transform.position, movePointLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;

        //最後の移動地点へ到着したら
        if (targetNo == movePointLists.Count - 1)
        {

            Spawn();

            GetComponent<PumpkinBossChildScr>().isSpawnMove = false;


        }
        else
        {
            targetNo++;
            direction = (movePointLists[targetNo].position - transform.position).normalized;
        }


    }


    public virtual void Spawn()
    {
        if (spawnObj == null)
            Debug.Log("Instantiate生成オブジェクトが設定されていない");

        Instantiate(spawnObj, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }
}

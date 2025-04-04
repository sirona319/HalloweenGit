using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPumpkinChild : StraightPointMove
{
    //PumpkinBossChildScr PumpkinBossChildScr;

    //[SerializeField] protected float noiseTiming = 1f;//ランダムで数字を足して　瞬間移動させる

    [SerializeField] protected GameObject[] spawnObjs;
    //bool isSpawn = false;
    //[SerializeField] public Transform[] spawnObjMovePoints;
    //[SerializeField] List<Transform> spawnPointLists = new();//生成したオブジェクトに設定する移動座標
    //[SerializeField] protected float setPointSpeed = 7f;
    //[SerializeField] float spdSetTiming;

    public override void Initialize()
    {
        //base.Initialize();d
    }

    public override void MoveEnter()
    {
        //base.MoveEnter();
        GetComponent<RotModule>().enabled = true;
        direction = (movePointLists[targetNo].position - transform.position).normalized;
    }

    public override void MoveExit()
    {
        //base.MoveEnter();
        GetComponent<RotModule>().enabled = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            //if (isSpawn) return;
            Spawn();

            //isSpawn = true;
            GetComponent<PumpkinBossChildScr>().isSpawnMove = false;
            gameObject.SetActive(false);
            //Destroy(gameObject);

        }
        else
        {
            targetNo++;
            direction = (movePointLists[targetNo].position - transform.position).normalized;
        }
        //base.MoveUpdate();

        //if (IsMoveEnd.Value)
        //{
        //    Spawn();


        //    GetComponent<PumpkinBossChildScr>().isSpawnMove = false;
        //}

    }


    public virtual void Spawn()
    {
        if (spawnObjs == null)
            Debug.Log("Instantiate生成オブジェクトが設定されていない");

        foreach(var obj in spawnObjs)
        {
            Instantiate(obj, transform.position, Quaternion.identity);

            //var spawnObjMovePoint = obj.GetComponent<SPointMovePumpkin>().movePointLists;
            //spawnPointLists.AddRange(spawnObjMovePoint);
            //obj.GetComponent<SPointMovePumpkin>().movePointLists = spawnPointLists;
        }


        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        //var eBase = obj.GetComponent<PumpkinScr>().move;
        //eBase.Initialize();

        //if (eBase.GetComponent<SPointMovePumpkin>() != null)
        //{
        //    eBase.GetComponent<SPointMovePumpkin>().SetSpeed(setPointSpeed, spdSetTiming);
        //    eBase.GetComponent<SPointMovePumpkin>().SetTarget(spawnPointLists);//spawnObjMovePoint[0].position;
        //}

        //if (this.GetComponent<LineRenderModule>() != null)
        //{
        //    this.GetComponent<LineRenderModule>().LineCreate(transform);
        //    this.GetComponent<LineRenderModule>().LineDraw();

        //    StartCoroutine(DelayOff(obj));

        //}


    }

    //public IEnumerator DelayOff(GameObject go)
    //{
    //    const float offLen = 0.3f;
    //    var endPos = movePointLists[movePointLists.Count - 1].position;

    //    yield return new WaitUntil(() => Vector3.Distance(endPos, go.transform.position) < offLen);//trueなら

    //    this.GetComponent<LineRenderModule>().SetOffTimer(0f);
    //    gameObject.SetActive(false);
    //}


}

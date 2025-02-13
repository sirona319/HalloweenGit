using NUnit.Framework;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static EnemySpawnWave;
using static UnityEngine.GraphicsBuffer;

public class PumpkinChildMove : MonoBehaviour
{
    public bool isFall=false;
    public bool isAllFall = false;

    [SerializeField] GameObject spawnObj;


    [SerializeField] public Transform[] moveTrans;
    //Vector3[] moveVecs;
    //List<Vector3> moveVecs= new List<Vector3>();

    [SerializeField] public Transform[] spawnObjMovePoints;
    //List<Vector3> spawnObjMovePointVecs = new List<Vector3>();

    [HideInInspector] float speed = 5f;
    const float ENDMOVELEN = 0.2f;
    int targetNo = 0;
    bool isMoveEnd = false;

    

    public void movePointSet(Transform[] ts)
    {
        moveTrans = ts;

        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    }

    public void Initialize()
    {
        //spawnObjMovePointVec = spawnObjMovePoint.position;

        ///foreach (Transform m in spawnObjMovePoints)
         //   spawnObjMovePointVecs.Add(m.position);

        //foreach (Transform m in moveTrans)
        //moveVecs.Add(m.position);

        //moveVecs=moveTrans

     }

    public void MoveEnter()
    {

    }

    public void MoveUpdateNoRot()
    {
        if (isMoveEnd) return;

        if (isFall)
        {
            if(isAllFall)
            {
                PumpkinMove();
            }
            ////ENDMOVELENのような ROTSTARTLENを作成する？　挙動が不自然なため
            /////transform.GetChild(0).rotation = MyLib.GetAngleRotationFuncs((transform.GetChild(0).position + Vector3.up), transform.GetChild(0), 5f);
            return;
        }

        PumpkinMove();


        //Vector3 direction = moveVecs[targetNo] - transform.position;
        //transform.position += direction.normalized * speed * Time.deltaTime;


        //transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, 5);

        //float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);

        //if (len < ENDMOVELEN + 0.8f)
        //{
        //    GetComponent<RotModule>().enabled = false;
        //ENDMOVELENのような　ROTSTARTLENを作成する？　挙動が不自然なため
        //    transform.GetChild(0).rotation = MyLib.GetAngleRotationFuncs((transform.GetChild(0).position + Vector3.up), transform.GetChild(0), 5f);

        //if (len < ENDMOVELEN)
        //{

        //    if (targetNo == 0)
        //    {
        //        isFall = true;
        //        GetComponent<RotModule>().enabled = false;
        //    }


        //    if (targetNo == moveTrans.Length - 1)
        //    {
        //        //ここに処理を追加できるようにしたい
        //        //IsPoint = true;
        //        var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);

        //    //赤かぼちゃは　消さないようにしたい
        //    //Destroy(obj, 5f);

        //        if (obj.name.Contains("pumpkin"))
        //    {
        //        StartCoroutine(MyLib.DelayCoroutine(5f, () =>
        //        {

        //            var iDamage = obj.transform.GetComponent<IDamage>();
        //            if (iDamage != null)
        //                iDamage.Damage(100);


        //        }));
        //    }




        //        obj.GetComponent<EnemyBase>().baseMove[0].Initialize();


        //        if (obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightPointMove>() != null)
        //            obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightPointMove>().SetTarget(spawnObjMovePointVecs);//spawnObjMovePoint[0].position;


        //        if (obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightForceMove>() != null)
        //            obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightForceMove>().SetTarget(spawnObjMovePointVecs[0]);//spawnObjMovePoint[0].position;


        //        gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;

        //        isMoveEnd = true;
        //    }
        //    else
        //        targetNo++;


        //}
        //else
        //{
        //    Vector3 direction = moveTrans[targetNo].position - transform.position;
        //    transform.position += direction.normalized * speed * Time.deltaTime;
        //}

        // }
        // else
        // {
        //     Vector3 direction = moveVecs[targetNo] - transform.position;
        //     transform.position += direction.normalized * speed * Time.deltaTime;
        // }

    }

    public void MoveUpdateNoRotisFall()
    {
        if (isMoveEnd) return;

        PumpkinMove();


    }
    public IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }


    void PumpkinMove()
    {
        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len > ENDMOVELEN)
        {
            Vector3 direction = moveTrans[targetNo].position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            return;
        }


        if (targetNo == 0)
        {
            isFall = true;
            GetComponent<RotModule>().enabled = false;
        }


        if (targetNo == moveTrans.Length - 1)
        {
            //ここに処理を追加できるようにしたい
            //IsPoint = true;
            var obj = Instantiate(spawnObj, moveTrans[targetNo].position, Quaternion.identity);
            var eBase = obj.GetComponent<EnemyBase>().baseMove[0];
            eBase.Initialize();


            if (eBase.GetComponent<StraightPointMove>() != null)
                eBase.GetComponent<StraightPointMove>().SetTarget(spawnObjMovePoints);//spawnObjMovePoint[0].position;


            if (eBase.GetComponent<StraightForceMove>() != null)
                eBase.GetComponent<StraightForceMove>().SetTarget(spawnObjMovePoints[0]);//spawnObjMovePoint[0].position;


            if (obj.name.Contains("Red"))
            {
                Debug.Log("赤かぼちゃ");
            }
            else
            {
                const float eraseTime = 5f;
                StartCoroutine(DelayCoroutine(eraseTime, () =>
                {

                    var iDamage = obj.transform.GetComponent<IDamage>();
                    if (iDamage != null)
                        iDamage.Damage(100,false);

                    Destroy(gameObject, 1f);
                    //gameObject.SetActive(false);

                }));
            }

            gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;

            isMoveEnd = true;
        }
        else
        {
            targetNo++;

        }

    }
}

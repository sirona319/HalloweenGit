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

    [SerializeField] public Transform[] spawnObjMovePoints;

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

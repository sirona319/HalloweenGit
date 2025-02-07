using System.Linq;
using UnityEngine;
using static EnemySpawnWave;
using static UnityEngine.GraphicsBuffer;

public class PumpkinChildMove : MonoBehaviour
{

  //  [SerializeField] public Transform[] spawnPumpkinMovePoint;
    [SerializeField] public Transform[] moveTrans;
    Vector3 moveVec;
    //Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.8f;

    //bool IsPoint = false;

    [SerializeField] float speed = 4f;

    [SerializeField] GameObject spawnObj;
    [SerializeField] public Transform[] spawnObjMovePoint;
    Vector3 spawnObjMovePointVec;
    //[SerializeField] Transform[] spawnObjTarget;

    bool isMoveEnd = false;

    

    public void movePointSet(Transform[] ts)
    {
        moveTrans = ts;

        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    }

    public void Initialize()
    {
        spawnObjMovePointVec = spawnObjMovePoint[0].position;
        moveVec = moveTrans[0].position;

    }

    public void MoveEnter()
    {

    }

    public void MoveUpdateNoRot()
    {
        if (isMoveEnd) return;

        Vector3 direction = moveVec/*moveTrans[targetNo].position*/ - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;


        //transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, 5);

        float len = Vector3.Distance(transform.position, moveVec);
        if (len < ENDMOVELEN)
        {

            targetNo++;
            if (targetNo > moveTrans.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;
                var obj = Instantiate(spawnObj, moveVec, Quaternion.identity);
                //Destroy(obj, 5f);

                //if(obj.GetComponent<EnemyBase>().GetBaseMove(0) == null)
                // Debug.Log("")
                //moveTrans[targetNo].position

                obj.GetComponent<EnemyBase>().baseMove[0].Initialize();

                //if (obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<PointMove>() != null)
                //    obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<PointMove>().moveTrans = spawnPumpkinMovePoint;

                if (obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightMove>() != null)
                {
                    //obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightMove>().Initialize();
                    obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightMove>().SetTarget(spawnObjMovePointVec);//spawnObjMovePoint[0].position;
                }

                if (obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightForceMove>() != null)
                {
                    //obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightForceMove>().Initialize();
                    obj.GetComponent<EnemyBase>().baseMove[0].GetComponent<StraightForceMove>().SetTarget(spawnObjMovePointVec);//spawnObjMovePoint[0].position;
                }


                gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;

                //spawnObj.GetComponent<PlayerAttackPointMove>().point.movePointSet(spawnObjTarget);

                //spawnObj.GetComponent<PlayerAttackPointMove>().playerAttack.TargetSet(GameObject.FindGameObjectWithTag("Player").transform);

                //かぼちゃの生成

                targetNo = 0;

                isMoveEnd = true;
            }

        }


    }
}

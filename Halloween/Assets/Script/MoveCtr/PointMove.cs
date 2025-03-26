using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;


public class PointMove : BaseMove
{
    [SerializeField]Transform[] moveTrans;
    [SerializeField] List<Vector3> moveVecs=new();

    int targetNo = 0;
    const float ENDMOVELEN = 0.8f;

    [SerializeField]float speed = 4f;

    //public void movePointSet(Transform[] ts)
    //{
    //    moveTrans = ts;

    //    if (moveTrans.Length <= 0)
    //        throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    //}

    public override void Initialize()
    {
        base.Initialize();

        foreach(Transform t in moveTrans)
        {
            moveVecs.Add(t.position);
        }
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        transform.position +=  transform.up * speed * Time.deltaTime;


        //transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, 5);
        transform.rotation = MyLib.GetAngleRotationFuncs(moveVecs[targetNo], transform, 5);


        //float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        float len = Vector3.Distance(transform.position, moveVecs[targetNo]);

        if (len < ENDMOVELEN)
        {

            targetNo++;
            if (targetNo > moveVecs.Count - 1)
            {
                //ここに処理を追加できるようにしたい ループするか　終了するか
                //IsPoint = true;

                targetNo = 0;
            }

        }


    }

}

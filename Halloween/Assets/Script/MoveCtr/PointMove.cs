using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;


public class PointMove : BaseMove
{
    [SerializeField]public Transform[] moveTrans;

    int targetNo = 0;
    const float ENDMOVELEN = 0.8f;

    [SerializeField]float speed = 4f;

    public void movePointSet(Transform[] ts)
    {
        moveTrans = ts;

        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    }

    public override void Initialize()
    {
        base.Initialize();

    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        transform.position +=  transform.up * speed * Time.deltaTime;


        transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, 5);

        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < ENDMOVELEN)
        {

            targetNo++;
            if (targetNo > moveTrans.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;

                targetNo = 0;
            }

        }


    }

}

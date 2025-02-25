using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;


public class PointMove : BaseMove
{
    [SerializeField]public Transform[] moveTrans;
    //Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.8f;

    //bool IsPoint = false;

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

        //targetNo = eBase.firstTargetPoints;

        //moveTrans = GetComponent<EnemyBase>().movePointsDatas;


    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        //if (!IsMove)
        //    return;

        //var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
        //m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);
        //var moveSpd = speed;

        //Vector2 rb2D = m_rb.position;
        //Vector2 up2D = transform.up;
        //Vector2 trans2D = transform.position;

        //Vector3 resultPos= rb2D + up2D * moveSpd * Time.deltaTime;
        //resultPos.z = 0f;
        //m_rb.MovePosition(resultPos);
        transform.position +=  transform.up * speed * Time.deltaTime;


        //const float INTERPOLANT = 5f;

        //Vector3 targetDirection = moveTrans[targetNo].position - transform.position;
        //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);

        transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, 5);

        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < ENDMOVELEN)
        {
            //if (GetComponent<BaseFlyScr>().enemyData.FirstTargetPlayer)
            //     return GetComponent<BaseFlyScr>().ReturnStateMoveType(StateType);

            //IsMove = false;

            targetNo++;
            if (targetNo > moveTrans.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;


                targetNo = 0;
            }
            //GetComponent<FlyScr>().IsMove = false;
            //return StateType;
        }


    }

}

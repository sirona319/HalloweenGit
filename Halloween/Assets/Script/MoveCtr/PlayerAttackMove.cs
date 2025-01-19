using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class PlayerAttackMove : BaseMove
{
    public Transform targetTrans;

    Vector3[] moveVecter;
    //Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.5f;

    public bool IsAttackEnd = false;

    public void TargetSet(Transform t)
    {
        targetTrans = t;



        if (moveVecter.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().name + "ムーブポイント未設定");
    }

    public override void Initialize()
    {
        base.Initialize();

        moveVecter = new Vector3[2];
        //targetNo = eBase.firstTargetPoints;

        //moveTrans = GetComponent<EnemyBase>().movePointsDatas;

    }

    public override void MoveEnter()
    {
        moveVecter[0] = transform.position;
        moveVecter[1] = targetTrans.position;
        IsAttackEnd = false;
    }

    public override void MoveUpdate()
    {
        //if (!IsMove)
        //    return;

        //var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
        //m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);
        var moveSpd = 4;

        //Vector2 rb2D = m_rb.position;
        //Vector2 up2D = transform.up;
        //Vector2 trans2D = transform.position;
        //Vector3 resultPos = rb2D + up2D + trans2D * moveSpd * Time.deltaTime;
        //resultPos.z = 0f;
        //m_rb.MovePosition(resultPos);
        transform.position = transform.position + transform.up * moveSpd * Time.deltaTime;



        //const float INTERPOLANT = 5f;

        //Vector3 targetDirection = moveVecter[targetNo] - transform.position;
        //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);

        
        transform.rotation = MyLib.GetAngleRotationFuncs(moveVecter[targetNo], transform, 5);//MyLib.TargetRotation2D(moveVecter[targetNo], transform);

        float len = Vector3.Distance(transform.position, moveVecter[targetNo]);
        if (len < ENDMOVELEN)
        {
            //if (GetComponent<BaseFlyScr>().enemyData.FirstTargetPlayer)
            //     return GetComponent<BaseFlyScr>().ReturnStateMoveType(StateType);

            //IsMove = false;

            targetNo++;
            if (targetNo > moveVecter.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;

                IsAttackEnd = true;
                targetNo = 0;
            }
            //GetComponent<FlyScr>().IsMove = false;
            //return StateType;
        }


    }
}

using UnityEngine;

public class PlayerAttackMove : BaseMove
{
    public Transform targetTrans;

    Vector3[] moveVecter;

    int targetNo = 0;
    const float ENDMOVELEN = 0.5f;

    public bool IsAttackEnd = false;
    float speed = 4f;
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

    }

    public override void MoveEnter()
    {
        moveVecter[0] = transform.position;
        moveVecter[1] = targetTrans.position;
        IsAttackEnd = false;
    }

    public override void MoveUpdate()
    {

        transform.position += transform.up * speed * Time.deltaTime;

        
        transform.rotation = MyLib.GetAngleRotationFuncs(moveVecter[targetNo], transform, 5);

        float len = Vector3.Distance(transform.position, moveVecter[targetNo]);
        if (len < ENDMOVELEN)
        {

            targetNo++;
            if (targetNo > moveVecter.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;

                IsAttackEnd = true;
                targetNo = 0;
            }

        }


    }
}

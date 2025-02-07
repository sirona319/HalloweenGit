using UnityEngine;

public class DirectionMove : BaseMove
{
    public float speed = 7f;
    float rotSpeed = 10f;
    float rotStopTime = 3f;

    public Vector3 targetsVec;

    //public bool isRot = true;
    //Vector2 targetDir;

    public void TargetSet(Vector3 t)
    {
        targetsVec = t;
        //targetDir = (targetsVec - transform.position).normalized;
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
        //if (isRot)
        RotUpdate();

        if(m_rb!=null)
            m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

    void RotUpdate()
    {
        if (rotStopTime <= 0) return;
        rotStopTime -= Time.deltaTime;

        transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    }
}

using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StraightPointMove : BaseMove
{
    const float ENDMOVELEN = 0.8f;

    public float speed = 7f;
    //float rotSpeed = 10f;
    //float rotStopTime = 3f;

    [SerializeField]Transform[] targets;// = new List<Vector3>();
    //public Vector3[] targetsVec;
    int targetNo = 0;
    //public bool isRot = true;
    //Vector2 targetDir;
    Vector3 direction;

    public ReactiveProperty<bool> IsLastPointMoveEnd = new ReactiveProperty<bool>(false);
    //public ReactiveProperty<bool[]> IsPointMoveEnd = new ReactiveProperty<bool[]>(new bool[] {false,false });

    public void SetTarget(Transform[] t)
    {
        targets = t;
        direction = targets[0].position - transform.position;
        //targetDir = (targetsVec - transform.position).normalized;

        //Debug.Log("SetTarget");
    }

    public override void Initialize()
    {
        base.Initialize();
        //Debug.Log("Initialize");
    }

    public override void MoveEnter()
    {
        //Debug.Log("MoveEnter");


        //if (m_rb3 != null)
        //    m_rb3.AddForce(/*m_rb3.position + */direction.normalized * speed, ForceMode.Impulse);
        //m_rb3.gameObject.GetComponent<Rigidbody>().AddForce(moveVector, ForceMode.VelocityChange);

        //m_rb3.MovePosition(m_rb3.position + direction.normalized * speed * Time.deltaTime);

    }

    public override void MoveUpdate()
    {
        //if (isRot)
        //RotUpdate();

        //AddForceに変更して　衝突座標からCollisionEnterで跳ね返る　VelocityChange?使用で　　MoveEnter??

        //if (m_rb != null)
        //    m_rb.MovePosition((Vector3)m_rb.position + direction.normalized * speed * Time.deltaTime);
        //else if (m_rb3 != null)
        //    m_rb3.MovePosition(m_rb3.position + direction.normalized * speed * Time.deltaTime);
        //else

        //direction = targetsVecs[targetNo] - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

       
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        if (len < ENDMOVELEN)
        {
            //最後の移動地点へ到着したら
            if (targetNo == targets.Length-1)
                IsLastPointMoveEnd.Value = true;
            else
            {
                targetNo++;
                direction = targets[targetNo].position - transform.position;
            }

           // Debug.Log("目標へ到着");
            //IsPointMoveEnd.Value = true;

        }

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

        }

    //void RotUpdate()
    //{
    //    if (rotStopTime <= 0) return;
    //    rotStopTime -= Time.deltaTime;

    //    transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    //}

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag=="Player")
    //        Debug.Log("Player");

    //    const int BlockReflect = 23;
    //    if (other.gameObject.layer== BlockReflect)
    //    {
    //        m_rb3.angularVelocity = m_rb3.angularVelocity.normalized * speed;
    //        m_rb3.linearVelocity = m_rb3.linearVelocity.normalized * speed;
    //        //m_rb3.angularVelocity
    //        //Debug.Log("reflectLayer23");
    //    }
    //}
}

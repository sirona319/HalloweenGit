using UnityEngine;

public class DirMoveModule : MonoBehaviour
{
    //[SerializeField] Vector3 direction;
    [SerializeField] float speed = 7f;
    [SerializeField] float vGravity = 0f;//疑似的な重力

   // const float ENDMOVELEN = 0.8f;

    //int targetNo = 0;

    //public ReactiveProperty<bool> IsLastPointMoveEnd = new ReactiveProperty<bool>(false);
    //目標地点に付いたときに処理をする用

    //public void SetTarget(Transform[] t)
    //{
    //    targets = t;
    //    direction = targets[0].position - transform.position;

    //}

    //public override void Initialize()
    //{
    //    base.Initialize();

    //}
    Vector3 direction;

    void Start()
    {
        //direction = transform.GetChild(0).position;
        direction = transform.GetChild(0).position - transform.position;
    }

    void Update()
    {
        //重力
        var t=transform.position;
        t.y += vGravity;
        transform.position = t;
        //

        transform.position += direction.normalized * speed * Time.deltaTime;
        //float len = Vector3.Distance(transform.position, targets[targetNo].position);

        //if (len < ENDMOVELEN)
        //{
        //    //最後の移動地点へ到着したら
        //    if (targetNo == targets.Length - 1)
        //        IsLastPointMoveEnd.Value = true;
        //    else
        //    {
        //        targetNo++;
        //        direction = targets[targetNo].position - transform.position;
        //    }

        //    // Debug.Log("目標へ到着");
        //    //IsPointMoveEnd.Value = true;

        //}

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }
}

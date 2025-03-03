using UnityEngine;

//https://feynman.co.jp/unityforest/unity-introduction/breakout-making/

public class CollisionRefrect : MonoBehaviour
{
    //ボールが当たった物体の法線ベクトル
    private Vector3 objNomalVector = Vector3.zero;
    // ボールのrigidbody
    private Rigidbody2D rb;
    // 跳ね返った後のverocity
    [HideInInspector] public Vector3 afterReflectVero = Vector3.zero;

    [SerializeField] float speed;

    //public enum DIRECTION
    //{
    //    right,
    //    left,
    //    up,
    //    down,
    //}

    //public DIRECTION dirType;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       // afterReflectVero = rb.linearVelocity.normalized * speed * 1.6f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //var speed = transform.parent.GetComponent<StraightForceMove>().speed*5f;
        //if (other.gameObject.tag == "Player")
        //   Debug.Log("Player");

        //var a =other.contacts[0].normal;


        const int BlockReflect = 23;
        if (other.gameObject.layer == BlockReflect)
        {
            /////Vector2.Reflect
            //rb.angularVelocity = 100f;

            //方向の計算
            //var dir = rb.linearVelocity - rb.position;
            
            rb.linearVelocity = rb.linearVelocity.normalized * speed;


            //// 当たった物体の法線ベクトルを取得
            //objNomalVector = other.contacts[0].normal;
            //Vector3 reflectVec = Vector3.Reflect(rb.linearVelocity.normalized * speed*1.6f, objNomalVector);
            //rb.linearVelocity = reflectVec;
            //// 計算した反射ベクトルを保存
            //afterReflectVero = rb.linearVelocity;


            //Debug.Log("nomal:" + other.contacts[0].normal);

        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    var speed = transform.parent.GetComponent<StraightForceMove>().speed * 1.6f;
    //    //if (other.gameObject.tag == "Player")
    //    //   Debug.Log("Player");

    //    //var a =other.contacts[0].normal;


    //    const int BlockReflect = 23;
    //    if (other.gameObject.layer == BlockReflect)
    //    {
    //        /////Vector2.Reflect
    //        //rb.angularVelocity = rb.angularVelocity * speed * 10;
    //        rb.linearVelocity = rb.linearVelocity.normalized * speed;


    //        //// 当たった物体の法線ベクトルを取得
    //        //objNomalVector = other.contacts[0].normal;
    //        //Vector3 reflectVec = Vector3.Reflect(afterReflectVero, objNomalVector);
    //        //rb.linearVelocity = reflectVec;
    //        //// 計算した反射ベクトルを保存
    //        //afterReflectVero = rb.linearVelocity;


    //        //Debug.Log("nomal:" + afterReflectVero);

    //    }
    //}





    //失敗
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    // Triggerで接触したオブジェクトは
    //    // 全てボールとみなすことにする
    //    var rb = other.GetComponent<Rigidbody2D>();
    //    if (rb == null) return;

    //    // 入射ベクトル（速度）
    //    var inDirection = rb.linearVelocity;

    //    // 法線ベクトル

    //    var inNormal = other.transform.up;

    //    if (dirType==DIRECTION.up)
    //        inNormal = other.transform.up;
    //    else if(dirType == DIRECTION.down)
    //        inNormal = -other.transform.up;
    //    else if (dirType == DIRECTION.right)
    //        inNormal = other.transform.right;
    //    else if (dirType == DIRECTION.left)
    //        inNormal = -other.transform.right;



    //    // 反射ベクトル（速度）
    //    var result = Vector2.Reflect(inDirection, inNormal);

    //    // バウンド後の速度をボールに反映
    //    rb.linearVelocity = result;
    //}

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    // Triggerで接触したオブジェクトは
    //    // 全てボールとみなすことにする
    //    var rb = other.transform.GetComponent<Rigidbody2D>();
    //    if (rb == null) return;

    //    // 入射ベクトル（速度）
    //    var inDirection = rb.linearVelocity;

    //    // 法線ベクトル

    //    var inNormal = other.transform.up;

    //    if (dirType == DIRECTION.up)
    //        inNormal = other.transform.up;
    //    else if (dirType == DIRECTION.down)
    //        inNormal = -other.transform.up;
    //    else if (dirType == DIRECTION.right)
    //        inNormal = other.transform.right;
    //    else if (dirType == DIRECTION.left)
    //        inNormal = -other.transform.right;



    //    // 反射ベクトル（速度）
    //    var result = Vector2.Reflect(inDirection, inNormal);

    //    // バウンド後の速度をボールに反映
    //    rb.linearVelocity = result;
    //}
}

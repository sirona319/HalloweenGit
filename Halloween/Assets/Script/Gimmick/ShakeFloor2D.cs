using UnityEngine;

//床を落とすやつ
public class ShakeFloor2D : MonoBehaviour
{
    Rigidbody2D rb2;
    Vector2 floorVelocity = Vector2.zero;
    Vector3 returnPos = Vector3.zero;
    [SerializeField] float fallSpeed = 0.1f;
    [SerializeField] float fallPoint = -8;
    bool isFall = false;

    PlayerMove pMove;
    bool isRide = false;

    void Start()
    {
        pMove = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>();
        rb2 = GetComponent<Rigidbody2D>();

        returnPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            floorVelocity -= new Vector2(0,fallSpeed * Time.deltaTime);

            rb2.MovePosition((Vector2)transform.position + floorVelocity);

            //プレイヤーが乗っている時の処理
            if (isRide)
            {
                pMove.RideMove(floorVelocity);
            }
        }
         

        if (transform.position.y < fallPoint)
        {
            isFall = false;
            transform.position = returnPos;
        }
           
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (isFall) return;
    //    //if (isShake)
    //    //    return;
    //    //isShake = true;
    //    returnPos = transform.position;

    //    #region カメラシェイク
    //    //https://baba-s.hatenablog.com/entry/2018/03/14/170400

    //    const float SHAKETIME = 1f;
    //    const float POW = 0.1f;
    //    StartCoroutine(MyLib.DoShake(SHAKETIME, POW, transform));

    //    StartCoroutine(MyLib.DelayCoroutine(SHAKETIME, () =>
    //    {
    //        GetComponent<Rigidbody2D>().gravityScale = 1;
    //        isFall = true;
    //        //m_animator.SetBool("Jump", false);
    //        //m_animator.SetBool("Fall", true);

    //    }));
    //    #endregion
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFall) return;

        //X方向だけの振動
        const float SHAKETIME = 1f;
        const float POW = 0.1f;
        StartCoroutine(MyLib.DoShake2D(SHAKETIME, POW, 0, transform));

        //落下処理
        StartCoroutine(MyLib.DelayCoroutine(SHAKETIME, () =>
        {
            if (GetComponent<Rigidbody>() != null)
                GetComponent<Rigidbody2D>().gravityScale = 1;

            isFall = true;

        }));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(TagName.Player))
        {
            isRide = false;
        }
    }
}

using UnityEngine;

public class JumpMove : BaseMove
{
    //public float speed = 7f;
    //const float rotSpeed = 5f;
    //float rotStopTime = 3f;

    //Vector3 targetsVec;
    //Vector2 targetDir;
    bool isGround = false;

    [SerializeField] Vector3 forceUpR;
    bool isRight = false;

    [SerializeField] Vector3 forceUpL;
    bool isLeft = false;

    //一定の位置まで行ったら　反対へ

    //開始位置の保存

    [SerializeField] Vector3 startPosition;//比較に使う

    [SerializeField] float maxJumpInterval = 1f;
    [SerializeField]float jumpInterval = 0f;

    [SerializeField] float jumpForceX=1;

    [SerializeField] float jumpForceY=1;
    [SerializeField] float moveEreaVal = 10;


    //public void TargetSet(Vector3 t)
    //{
    //    //targetsVec = t;
    //    //targetDir = (targetsVec - transform.position).normalized;
    //}

    public override void Initialize()
    {
        base.Initialize();


        startPosition = transform.position;

        //右上
        forceUpR = transform.right + transform.up;
        forceUpR.x *= jumpForceX;
        forceUpR.y *= jumpForceY;

        //左上
        forceUpL = -transform.right + transform.up;

        forceUpL.x *= jumpForceX;
        forceUpL.y *= jumpForceY;

        jumpInterval = maxJumpInterval;

        isRight = true;
        isLeft = false;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPosition;
        }

            if (jumpInterval > 0f)
            jumpInterval-=Time.deltaTime;


        if (jumpInterval < 0f)
        {
            if (transform.position.x > startPosition.x+ moveEreaVal)
            {
                isRight = false;
                isLeft = true;
            }
            else if(transform.position.x < startPosition.x- moveEreaVal)
            {
                isRight = true;
                isLeft = false;
            }

            if(isRight)
                m_rb.AddForce(forceUpR, ForceMode2D.Impulse);
            else if(isLeft)
                m_rb.AddForce(forceUpL, ForceMode2D.Impulse);



            jumpInterval = maxJumpInterval;
        }



         //if(isGround)
        //    transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, 3f);


        //    if (GetComponent<RotModule>())
        //       GetComponent<RotModule>().enabled = true;

        //RotUpdate();

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    //if (other.CompareTag("Player"))
    //    //{
    //    //    //プレイヤーへのダメージ処理
    //    //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);

    //    //    //Debug.Log("攻撃がPlayerにHIT");

    //    //    PoolDestroy();
    //    //    return;
    //    //}

    //    if (other.CompareTag("Ground"))
    //    {
    //        m_rb.linearVelocity = new Vector2(0f,0f);

    //        Debug.Log("地面hit");
    //        //PoolDestroy();
    //        return;
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D other)
    {

        //if (other.CompareTag("Player"))
        //{
        //    //プレイヤーへのダメージ処理
        //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);

        //    //Debug.Log("攻撃がPlayerにHIT");

        //    PoolDestroy();
        //    return;
        //}

        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            m_rb.linearVelocity = new Vector2(0f, 0f);

            m_rb.freezeRotation = true;
            if (GetComponent<RotModule>())
                GetComponent<RotModule>().enabled = false;
            Debug.Log("地面hit"+this.gameObject.name);
            //PoolDestroy();
            return;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {

        //if (other.CompareTag("Player"))
        //{
        //    //プレイヤーへのダメージ処理
        //    other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);

        //    //Debug.Log("攻撃がPlayerにHIT");

        //    PoolDestroy();
        //    return;
        //}

        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            m_rb.freezeRotation = false;

            if (GetComponent<RotModule>())
                GetComponent<RotModule>().enabled = true;
            //m_rb.linearVelocity = new Vector2(0f, 0f);

            Debug.Log("地面から離れた" + this.gameObject.name);
            //PoolDestroy();
            return;
        }

    }

    //void RotUpdate()
    //{
    //    if (rotStopTime <= 0) return;
    //    rotStopTime -= Time.deltaTime;

    //    transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    //}
}

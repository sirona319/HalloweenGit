using AIE2D;
using UniRx;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region デバッグ
    [SerializeField, HeaderAttribute("DEBUG")]
    float debugmoveX = 0;

    [SerializeField] Transform startT;
    public bool isStartPos= false;

    [SerializeField] Transform bossT;
    public bool isBossPos = false;
    #endregion


    #region 移動
    [SerializeField, HeaderAttribute("MOVE")]

    Animator m_animator;

    Rigidbody2D m_rb;                   //剛体
    [SerializeField] Vector2 m_movement;
    public float maxMoveSpeed= 3.6f;
    public float moveSpeed= 3.6f;             //移動速度
    [SerializeField] ReactiveProperty<bool> isGround /*{ get; set; }*/ = new ReactiveProperty<bool>(true);
    //public bool IsGround => isGround.Value;
    public bool IsGround
    {
        get => isGround.Value;
        set => isGround.Value = value;
    }

    [SerializeField] bool isLimitMove = false;     //アニメーション中などの移動制限
    [SerializeField] float skyGravity = 22;
    [SerializeField] float groundGravity = 1; //ダッシュ対応のため1

    //ジャンプ
    const float upSpd = 4f;
    public bool isJump = false;
    [SerializeField] float jumpHeight=2f; //1.8
    float keepPosY;


    //ダッシュ
    bool isDash = false;
    bool isSkyDash = false;
    [SerializeField] float dashLen = 10;//10
    [SerializeField] float dashStopTime = 0.3f;//0.3f
    #endregion

    //[SerializeField] GameObject deadKnife;


    //public void PlayerDead()
    //{
    //    GetComponent<PlayerScr2D>().isDead = true;
    //    m_animator.SetBool("dead", true);
    //}

    public bool isNoise = false;

    [SerializeField]PlayerGroundCollider pGroundCol;

    void DebugSetPosition()
    {
        if (isStartPos)
            this.transform.position = startT.position;

        if (isBossPos)
            this.transform.position = bossT.position;
    }
    void Start()
    {
        //デバッグ用　座標
        DebugSetPosition();

        //m_animator.SetBool("isStart", true);
        //moveSpeed = maxMoveSpeed;

        //アニメーションイベントで解除する
        //isLimitMove = true;
        //ダッシュ残像のオフ
        GetComponent<DynamicAfterImageEffect2DPlayer>().SetActive(false);

        moveSpeed = maxMoveSpeed;

        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();


        isGround.Skip(1).Subscribe(ground =>
        {
            if (ground == false)
                m_rb.gravityScale = skyGravity;
            else
            {
                m_rb.gravityScale = groundGravity;
                isSkyDash = false;
            }
        });


        var SaveMgr = GameObject.FindGameObjectWithTag(TagName.SaveM).GetComponent<Save>();
        if (SaveMgr.isLoad)
        {
            Vector3 loadPos;
            loadPos.x = PlayerPrefs.GetFloat("POSX");
            loadPos.y = PlayerPrefs.GetFloat("POSY");
            loadPos.z = PlayerPrefs.GetFloat("POSZ");
            transform.position = loadPos;

            SaveMgr.isLoad = false;
        }
    }

    private void Update()
    {
        if (GetComponent<PlayerScr2D>().isDead) return;
        if (isLimitMove) return;

        MoveControl();
        Dash();

        if (Input.GetKeyDown(KeyCode.Space) && isGround.Value)
        {
            isJump = true;
            isGround.Value = false;
            keepPosY = transform.position.y;

            MyLib.MyPlayOneSound("Sound/SE/wave/パンチ素振り", 1f, gameObject);
        }

        JumpControl();


    }

    void FixedUpdate()
    {

        if (GetComponent<PlayerScr2D>().isDead) return;
        if (isDash) return;

        m_rb.MovePosition((Vector2)transform.position + m_movement * moveSpeed * Time.deltaTime);

    }

    public void RideMove(Vector2 f)
    {
        m_rb.MovePosition(((Vector2)transform.position + m_movement * moveSpeed * Time.deltaTime)
                + f);
    }

    void MoveControl()
    {
        //テスト用
        debugmoveX = Input.GetAxis("Horizontal");
        // 入力の取得
        m_movement.x = Input.GetAxis("Horizontal");
        m_movement.y = 0f;//Input.GetAxis("Vertical");


            const float walkAnimSpd = 0.3f;
        if (m_movement.x >= walkAnimSpd&&!isNoise)
            GetComponent<SpriteRenderer>().flipX = true;
        if (m_movement.x <= -walkAnimSpd)
            GetComponent<SpriteRenderer>().flipX = false;

        var absX = Mathf.Abs(m_movement.x);
        //速度が一定を超えたら　アニメーションの設定
        if (absX > walkAnimSpd)
            m_animator.SetBool("walk", true);
        else
            m_animator.SetBool("walk", false);
    }

    void Dash()
    {
        //g = m_rb.gravityScale;
        if (isDash) return;
        if (isSkyDash) return;
        if (!Input.GetKeyDown(KeyCode.LeftShift)) return;

        //Debug.Log("ダッシュ");

        isDash = true;
        GetComponent<DynamicAfterImageEffect2DPlayer>().SetActive(true);

        if (!IsGround)
        {
            m_rb.gravityScale = 0;
            isSkyDash = true;

            isJump = false;
            //m_movement.y = 0f;
        }


        if (GetComponent<SpriteRenderer>().flipX)
            m_rb.AddForce(((Vector2.right * dashLen)), ForceMode2D.Impulse);
        else
            m_rb.AddForce(((-Vector2.right) * dashLen), ForceMode2D.Impulse);


        StartCoroutine(MyLib.DelayCoroutine(dashStopTime, () =>
        {
            GetComponent<DynamicAfterImageEffect2DPlayer>().SetActive(false);
            if (IsGround)
            {
                isSkyDash = false;
                m_rb.gravityScale = groundGravity;

            }
            else
            {
                m_rb.gravityScale = skyGravity;
            }

            m_rb.linearVelocity = Vector2.zero;
            //Debug.Log("DASHOFF");
            isDash = false;
        }));

    }

    void JumpControl()
    {
        if (!isJump) return;
        m_movement.y += upSpd;

        //現在の高さからジャンプ高度へ到達したら終了
        if (transform.position.y > keepPosY + jumpHeight)
        {
            isJump = false;
        }

        //地面にいるとき　真上にオブジェクトがあるときのジャンプ対策　両方がtrueの時
        //if (IsGround)
        //    isJump = false;
    }


    public void MoveStop()
    {
        isLimitMove = true;
        moveSpeed = 0f;
    }

    public void MoveActive()
    {
        if(!m_animator.GetBool("isStart")) return;
        isLimitMove = false;
        moveSpeed = maxMoveSpeed;
    }

    #region タイムラインイベント

    public void StartMoveActive()
    {
        //GetComponent<PlayerHp>().AbsDamage(100);
        m_animator.SetBool("isStart", true);
        //if (!m_animator.GetBool("isStart")) return;
        //isLimitMove = false;
        moveSpeed = maxMoveSpeed;
    }

    #endregion


    #region　アニメーションイベント　プレイヤー

    public void StartAnimEnd()
    {
        //フラグをオフ
        isLimitMove = false;
        Debug.Log("isLimitMove = false;");
    }


    #endregion

}

﻿using UnityEngine;

public class PlayerScr2D : MonoBehaviour,IDamage
{
    # region デバッグ
    public float debugmoveX = 0;
    public bool DEBUGNoDamage = false;
    #endregion

    #region 移動
    Rigidbody2D m_rb;      //剛体
    [SerializeField] Vector2 m_movement;
    public float maxMoveSpeed;
    public float moveSpeed;   //移動速度
    public bool isGround = true;
    public bool isLimitMove = true;    //アニメーション中などの移動制限

    //ジャンプ
    public bool isJump = false;
    [SerializeField] float jumpHeight; //1.8
    float keepPosY;
    #endregion

    #region 攻撃
    readonly float MAXATKINTERVAL = 1;
    float atkInterval = 0;
    TargetMagazine nMag;     //ナイフ
    #endregion

    Animator m_animator;
    public bool isDamage = false;
    public bool isDead = false;
    public int hp = 3;

    [SerializeField] PlayerDamage pDamage;

    //const float ROTSPEED = 3f;
    //Vector2 m_targetDirection;
    //public bool IsDash { get; private set; } = false;

    //public void StopMove()
    //{
    //    m_rb.MovePosition(m_rb.position+new Vector2(0,0));
    //    m_rb.angularVelocity = 0;
    //    //m_rb.linearVelocity= new Vector2(0, 0);
    //}

    // #endregion
    void Start()
    {
        moveSpeed = maxMoveSpeed;

        if(GetComponent<PlayerDamage>()!=null)
            pDamage = GetComponent<PlayerDamage>();

        nMag = GetComponent<TargetMagazine>();
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

        nMag.TargetSet(nMag, nMag.bulletTarget, this.gameObject);
    }

    void Update()
    {
        if (isDead) return;

        if(atkInterval > 0) 
            atkInterval-=Time.deltaTime;

        //MoveControl();     //移動用関数
        if (Input.GetKeyDown(KeyCode.F) && atkInterval <= 0)
        {
            //nMag.targetPos = (transform.position + Vector3.up) - transform.position;
            nMag.MagazineEnter();
            atkInterval = MAXATKINTERVAL;

            //ビーム砲チャージ
            //MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
        }


        // 入力の取得
        m_movement.x = Input.GetAxis("Horizontal");
        m_movement.y = 0f;//Input.GetAxis("Vertical");

        var AbsX = Mathf.Abs(m_movement.x);

        debugmoveX= Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            isJump = true;
            isGround = false;
            keepPosY =transform.position.y;
          
            //m_movement.y += 20.0f;
        }

        JumpControl();

        //アニメーションの設定
        if (AbsX>0.3f)
            m_animator.SetBool("walk", true);
        else
            m_animator.SetBool("walk", false);
    }

    void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + m_movement * moveSpeed * Time.fixedDeltaTime);
    }

    void JumpControl()
    {
        if (!isJump) return;
        m_movement.y += 4f;

        if(transform.position.y>keepPosY+jumpHeight)
        {
            isJump = false;
        }
    }

//    void MoveControl()
//    {
//        //進行方向計算
//        //キーボード入力を取得
//        float v;
//        float h;
//#if UNITY_IOS
////対象プラットフォームがiOSの時だけコンパイルされる	
//#elif UNITY_ANDROID
//        //v = m_variableJoystick.Vertical;
//        //h = m_variableJoystick.Horizontal;
//        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
//        {
//            //v = m_variableJoystick.Vertical;
//            //h = m_variableJoystick.Horizontal;

//            //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
//            Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
//            //if(m_isWater)Sword
//            //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

//            Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

//            //var targetDirection = Vector3.zero;
//            //カメラの方向を考慮したキャラの進行方向を計算
//            m_targetDirection = m_variableJoystick.Horizontal * right + m_variableJoystick.Vertical * forward;
//            //m_input = new Vector3(m_variableJoystick.Horizontal, 0f, m_variableJoystick.Vertical);//対象プラットフォームがAndroidの時だけコンパイルされる
//        }
//        SPEED = 4f;
//#else
//        v = Input.GetAxisRaw("Vertical");         //InputManagerの↑↓の入力
//        h = Input.GetAxisRaw("Horizontal");       //InputManagerの←→の入力 

//        //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
//        Vector3 forward = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 1, 0)).normalized;
//        //if(m_isWater)Sword
//        //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

//        Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

//        //var targetDirection = Vector3.zero;
//        //カメラの方向を考慮したキャラの進行方向を計算
//        //m_targetDirection = h * right + v * forward;
//#endif

//        //移動のベクトルを計算
//       // m_moveDirection = m_targetDirection * SPEED;

//        //2D処理
//        //m_moveDirection.y = m_moveDirection.z;
//        //m_moveDirection.z = 0;
//        //
//       // m_moveDirection.y = 0;
//        //var resultPos = MoveLimit(m_rb.position + m_moveDirection * Time.deltaTime);

//        //transform.position = m_rb.position + m_moveDirection * Time.deltaTime;
//        //m_rb.MovePosition(m_rb.position + m_moveDirection * Time.deltaTime);

//        //1f前の座標との差を保存
//        //prePosDiff.Value = m_moveDirection * Time.deltaTime;
//    }

//    //Vector3 MoveLimit(Vector3 pos)
//    //{

//    //    const float XLIMIT = 8.5f;
//    //    const float YLIMIT = 4.5f;
//    //    //Vector3 resultPos = pos;
//    //    pos.x = Mathf.Clamp(pos.x, -XLIMIT, XLIMIT);
//    //    pos.y = Mathf.Clamp(pos.y, -YLIMIT, YLIMIT);

//    //    return pos;
//    //}

//    void RotationControl()
//    {
//        //Vector3 rotateDirection = m_moveDirection;

//        ////それなりに移動方向が変化する場合のみ移動方向を変える
//        //if (rotateDirection.sqrMagnitude > 0.01)
//        //{
//        //    //緩やかに移動方向を変える
//        //    float step = ROTSPEED * Time.deltaTime;
//        //    Vector3 newDir = Vector3.Slerp(transform.forward, rotateDirection, step);
//        //    transform.rotation = Quaternion.LookRotation(newDir);
//        //}
//    }

    public void Damage(int damage)
    {
        //回避の実行中なら無効またはダメージ中なら無効　無敵 デバッグ用
        if (DEBUGNoDamage) return;
        if (isDead) return;
        if (isDamage) return;
        ////if (m_isDash) return;　ダッシュ時無敵
        pDamage.Damage(damage);

    }

    #region　アニメーションイベント　プレイヤー

    public void StartAnimEnd()
    {
        //フラグをオフ
        isLimitMove = false;
        //Debug.Log("isLimitMove = false;");
    }
    #endregion

    #region　剛体関連
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Test");
        if (collision.gameObject.CompareTag(TagName.Enemy))
        {
            //プレイヤーへのダメージ処理
            Damage(1);

        }

        //if (collision.gameObject.CompareTag("EnemyBoss"))
        //{
        //    //Debug.Log("ColPlayer");
        //    Destroy(this);
        //    //プレイヤーへのダメージ処理
        //    PlayerDamage(1);
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        if(isJump)
    //        isJump = false;
    //        //Debug.Log("GROUND TRUE");
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Ground"))
    //    {

    //        isGround = false;
    //        Debug.Log("GROUND FALSE");
    //    }
    //}


    //private void OnTriggerEnter(Collider other)
    //{

    //}

    //private void OnTriggerStay(Collider other)
    //{
    //   // if (other.CompareTag("Water"))
    //    //{
    //        //m_animation.CrossFade(AnimState.runCustom.ToString());
    //        //m_rb.useGravity = false;
    //    //}
    //}

    //private void OnTriggerExit(Collider other)
    //{


    //}
    #endregion


}
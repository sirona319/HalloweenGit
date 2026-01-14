using TMPro;
using UnityEngine;

//プレイヤーはシーン遷移ごとに消去されて再生成される
//[RequireComponent(typeof(コンポーネント名))]
[DisallowMultipleComponent]
public class PlayerScr2D : MonoBehaviour
{
    public bool DEBUGNoDamage = false;


    PlayerMagazine mag;

    Animator m_animator;
    public bool isDead = false;

    [SerializeField] TextMeshProUGUI timeText;//一時停止テキスト
    public void PlayerDead()
    {
        GetComponent<PlayerScr2D>().isDead = true;
        m_animator.SetBool("dead", true);

        //イベントカメラが適用されていたら？
        Camera.main.GetComponent<CameraControl>().CameraEventTriggerOff();
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    private void Start()
    {
        Camera.main.GetComponent<CameraControl>().cameraTarget = this.transform.Find("CameraTarget").transform;

        m_animator = GetComponent<Animator>();

        mag = GetComponent<PlayerMagazine>();
        //tMag.TargetSet(tMag, tMag.bulletTarget, this.gameObject);
        mag.MagazineEnter();

        var gMgr = GameObject.FindGameObjectWithTag(TagName.GameController).GetComponent<GameMgr>();
        if (gMgr.isChangePlayer)
        {
            //transform.position = gMgr.playerPos;

            var pHp = GetComponent<PlayerHp>();
            pHp.hp = gMgr.playerHp;
            pHp.UpdateLifeImage();

            gMgr.isChangePlayer = false;
            //return;
        }

    }

    private void Update()
    {
        if (GetComponent<PlayerScr2D>().isDead) return;

        //攻撃
        mag.MagazineUpdate();

        //Pause();

    }

    void Pause()
    {
        //一時停止
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            timeText.enabled = true;
            //画面暗くして　TIME　UI表示
        }

        //Return==Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            timeText.enabled = false;
        }

    }



    #region　剛体関連
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //   // Debug.Log("Test");
    //    if (collision.gameObject.CompareTag(TagName.Enemy))
    //    {
    //        MyLib.DebugInfo(gameObject);
    //        //プレイヤーへのダメージ処理
    //        Damage(1);

    //    }

    //    //if (collision.gameObject.CompareTag("EnemyBoss"))
    //    //{
    //    //    //Debug.Log("ColPlayer");
    //    //    Destroy(this);
    //    //    //プレイヤーへのダメージ処理
    //    //    PlayerDamage(1);
    //    //}
    //}

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
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(コンポーネント名))]
[DisallowMultipleComponent]
public class PlayerScr2D : MonoBehaviour
{

    PlayerMagazine mag;

    Animator m_animator;
    public bool isDead = false;

    public TextMeshProUGUI timeText;//一時停止テキスト
    public void PlayerDead()
    {
        //GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<PlayerScr2D>().isDead = true;
        m_animator.SetBool("dead", true);

        Camera.main.GetComponent<CameraControl>().CameraEventTriggerOff();
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();

        mag = GetComponent<PlayerMagazine>();
        //tMag.TargetSet(tMag, tMag.bulletTarget, this.gameObject);
    }

    private void Update()
    {
        if (GetComponent<PlayerScr2D>().isDead) return;

        //攻撃
        mag.MagazineUpdate();


        //一時停止
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            timeText.enabled = true;
            //画面暗くして　TIME　UI表示
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            timeText.enabled = false;
        }
        //
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
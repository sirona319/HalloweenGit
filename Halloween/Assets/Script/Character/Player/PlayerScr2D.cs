﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(コンポーネント名))]
[DisallowMultipleComponent]
public class PlayerScr2D : MonoBehaviour
{
    ////移動させる画像
    //public Image eyeImageUp;
    //public Image eyeImageDown;
    ////

    //public Image closeEyeImageUp1;
    //public Image closeEyeImageDown1;
    //public Image closeEyeImageUp2;
    //public Image closeEyeImageDown2;
    //public Image closeEyeImageUp0;
    //public Image closeEyeImageDown0;
    //public TextMeshProUGUI reviveText;

    #region 攻撃
    readonly float MAXATKINTERVAL = 1;
    float atkInterval = 0;
    TargetMagazine tMag;     //ナイフ
    #endregion

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

        tMag = GetComponent<TargetMagazine>();
        tMag.TargetSet(tMag, tMag.bulletTarget, this.gameObject);
    }

    private void Update()
    {
        if (GetComponent<PlayerScr2D>().isDead) return;

        //攻撃
        if (atkInterval > 0)
            atkInterval -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && atkInterval <= 0)
        {
            //nMag.targetPos = (transform.position + Vector3.up) - transform.position;
            tMag.MagazineEnter();
            atkInterval = MAXATKINTERVAL;

        }
        //


        //一時停止
        if(Input.GetKeyDown(KeyCode.Escape))
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
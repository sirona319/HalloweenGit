using UnityEngine;

public class PlayerDamage : MonoBehaviour,IDamage
{
    [SerializeField] PlayerScr2D pScr;


    #region ダメージ
    //bool isDead = false;

    //public bool isDamage = false;
    [SerializeField] float damageTimeMax = 1f;
    [SerializeField] float damageTime = 0;

    //点滅処理
    const float duration = 0.07f;
    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);
    #endregion

    void Start()
    {
        if (GetComponent<PlayerScr2D>() != null)
            pScr = GetComponent<PlayerScr2D>();
    }

    void Update()
    {
        //点滅処理
        if (damageTime > 0)
        {
            GetComponent<SpriteRenderer>().material.color =
                Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, damageTimeMax));

            damageTime -= Time.deltaTime;

        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = startColor;
            pScr.isDamage = false;
        }
    }

    public void Damage(int damage)
    {

        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        ////揺らす長さ
        //const float shakeLength = 0.3f;
        ////揺らす力
        //const float power = 0.3f;

        //StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion
        //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        pScr.hp -= damage;        //HP減少処理

        pScr.isDamage = true;

        if (pScr.hp <= 0)
            pScr.isDead = true;


        #region サウンド
        //const float volumeAtk = 0.1f;
        //var audioSource = this.GetComponent<AudioSource>();
        //var soundAtk = (AudioClip)Resources.Load("SE/" + "小パンチ");
        //audioSource.PlayOneShot(soundAtk, volumeAtk);
        #endregion

        ////  m_hpSkin[m_hp].enabled = false;        //HPUIの非表示

        #region シーン遷移

        //const float DAMAGETIME = 1.5f;
        //StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        //{
        //    // DAMAGETIME秒後にここの処理が実行される
        //    //skin.material.color = startColor;
        //    m_isDamage = false;
        //    if (hpUI.GetHp() <= 0)
        //    {
        //        m_isDead = true;
        //        // skin.enabled = false;

        //        //循環参照してしまっている？
        //        //死亡処理
        //        Debug.Log("死んだよタイトル遷移するよ！");
        //        GameObject.Find("GAMEOVERTEXT").GetComponent<DOFade>().ShowWindow();
        //        //死亡UI表示
        //        //GameObject.Find("DeadText").GetComponent<DOFade>().ShowWindow();

        //        //エクストラモードの場合ランキング表示
        //        //クリアチェック　スコア加算　エクストラシーン
        //        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
        //        {
        //            //クリア失敗なのでfalse
        //            //  ExtraControl.I.ShowRanking(false);
        //            GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());

        //        }
        //        else
        //        {
        //            //タイトルシーン遷移
        //            GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());
        //        }

        //    }

        //}));
        #endregion
    }

    //public void Damage(int damage, bool deadSound)
    //{
    //    Damage(damage);
    //    pScr.GetComponent<CreateDeadSound>().IsSoundEnable = deadSound;
    //}
}

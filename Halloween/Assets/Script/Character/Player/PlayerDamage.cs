using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour,IDamage
{
    [SerializeField] PlayerScr2D pScr;

    //const int LIMITHP = 10;

    [Range(1, 10)]
    [SerializeField] public int MAXHP = 3;
    #region ダメージ
    [SerializeField] float damageTimeMax = 1f;
    [SerializeField] float damageTime = 0;


    SpriteRenderer pSprite;
    [SerializeField] Image[] lifeImage;

    public int hp;

    //点滅処理
    const float duration = 0.07f;
    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);
    #endregion

    bool isDamage = false;

    bool IsDeadHp()
    {
        return hp <= 0;
    }

    public bool IsHpMax()
    {
        return hp >= MAXHP;
    }

    void Start()
    {
        if (GetComponent<PlayerScr2D>() != null)
            pScr = GetComponent<PlayerScr2D>();

        if (GetComponent<SpriteRenderer>() != null)
            pSprite = GetComponent<SpriteRenderer>();

        //ロード用？
        //for (int i = LIMITHP - 1; i > hp - 1; i--)
        //{
        //    if (i < hp - 1) break;

        //    lifeImage[i].enabled = false;
        //    //hp--;
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //回避の実行中なら無効またはダメージ中なら無効　無敵 デバッグ用
            if (pScr.DEBUGNoDamage) return;
            if (pScr.isDead) return;
            if (isDamage) return;

            DamageLife(4);

            isDamage = true;
            damageTime = damageTimeMax;

            if (hp <= 0)
            {
                pScr.PlayerDead();
                //Destroy(gameObject);
            }
        }

        if (isDamage == false) return;

        //点滅処理
        if (damageTime > 0)
        {
            pSprite.material.color =
                Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, damageTimeMax));

            damageTime -= Time.deltaTime;

        }
        else
        {
            pSprite.material.color = startColor;
            isDamage = false;
        }
    }


    //public void Damage(int damage)
    //{
    //    //回避の実行中なら無効またはダメージ中なら無効　無敵 デバッグ用
    //    if (DEBUGNoDamage) return;
    //    if (isDead) return;
    //    if (isDamage) return;
    //    ////if (m_isDash) return;　ダッシュ時無敵
    //    pDamage.Damage(damage);

    //}

    public void Damage(int damage)
    {
        //回避の実行中なら無効またはダメージ中なら無効　無敵 デバッグ用
        if (pScr.DEBUGNoDamage) return;
        if (pScr.isDead) return;
        if (isDamage) return;
        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        ////揺らす長さ
        //const float shakeLength = 0.3f;
        ////揺らす力
        //const float power = 0.3f;

        //StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion
        //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        //hp -= damage;        //HP減少処理
        DamageLife(damage);

        isDamage = true;
        damageTime = damageTimeMax;

        if (hp <= 0)
        {
            pScr.PlayerDead();
            //Destroy(gameObject);
        }


        #region サウンド
        //const float volumeAtk = 0.1f;
        //var audioSource = this.GetComponent<AudioSource>();
        //var soundAtk = (AudioClip)Resources.Load("SE/" + "小パンチ");
        //audioSource.PlayOneShot(soundAtk, volumeAtk);
        #endregion

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

    void DamageUpdate(int damage)
    {
        for (int i = hp - 1; damage > 0; damage--, i--)
        {
            if (i < 0) break;

            lifeImage[i].enabled = false;
            hp--;
        }

        //if (!IsDeadHp()) return;
        //player.PlayerDead();
    }

    //public void Damage(int damage, bool deadSound)
    //{
    //    Damage(damage);
    //    pScr.GetComponent<CreateDeadSound>().IsSoundEnable = deadSound;
    //}

    //HPのダメージ表現
    void DamageLife(int damage)
    {

        int saveValue = damage;

        const float DAMAGETIME = 0.3f;

        for (int i = hp - 1/*,j = 0*/; damage > 0; damage--, i--)
        {
            if (i < 0) break;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(DAMAGETIME, POW, lifeImage[i].transform));

        }

        //成功
        StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        {
            DamageUpdate(saveValue);
        }));

    }


    //回復
    public void HealLife(int heal)
    {

        for (int i = hp; heal > 0; heal--, i++)
        {
            if (i > MAXHP - 1) break;

            lifeImage[i].enabled = true;

            if (hp < MAXHP)
                hp++;

        }


    }
}

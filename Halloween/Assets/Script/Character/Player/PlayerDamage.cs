using UnityEngine;

public class PlayerDamage : MonoBehaviour,IDamage
{

    PlayerScr2D pScr;
    PlayerHp playerHp;
    PlayerUI playerUI;


    public bool IsDamage { get; set; } = false;

    [SerializeField] float damageTimeMax = 1f;
    [SerializeField] float damageTime = 0;



    //点滅処理
    SpriteRenderer pSprite;

    const float duration = 0.07f;
    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pScr = GetComponent<PlayerScr2D>();
        playerHp = GetComponent<PlayerHp>();
        playerUI = GameObject.FindWithTag("PlayerUI").GetComponent<PlayerUI>();

        pSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        MatBlink(); //マテリアル点滅

    }

    public bool Damage(int damage)
    {
        //回避の実行中なら無効またはダメージ中なら無効　無敵 デバッグ用
        if (pScr.DEBUGNoDamage) return false;
        if (pScr.isDead) return false;
        if (IsDamage) return false;
        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        ////揺らす長さ
        //const float shakeLength = 0.3f;
        ////揺らす力
        //const float power = 0.3f;

        //StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion

        DamageLife(damage);

        const float volume = 0.5f;
        MyLib.MyPlaySound("Sound/SE/wave/damaged1", volume, gameObject);

        IsDamage = true;
        damageTime = damageTimeMax;


        return true;

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
        //        if (GameMgr.I.IsSceneName(GameMgr.SceneNameType.GameScene.ToString()))
        //        {
        //            //クリア失敗なのでfalse
        //            //  ExtraControl.I.ShowRanking(false);
        //            GameMgr.I.SceneChangeTimerSet(GameMgr.SceneNameType.TitleScene.ToString());

        //        }
        //        else
        //        {
        //            //タイトルシーン遷移
        //            GameMgr.I.SceneChangeTimerSet(GameMgr.SceneNameType.TitleScene.ToString());
        //        }

        //    }

        //}));
        #endregion
    }

    public void AbsDamage(int damage)
    {
        if (pScr.isDead) return;

        DamageLife(damage);

        IsDamage = true;
        damageTime = damageTimeMax;

    }

    void DamageUpdate(int damage)
    {
        for (int i = playerHp.hp - 1; damage > 0; damage--, i--)
        {
            if (i < 0) break;

            playerUI.lifeImage[i].enabled = false;
            playerHp.hp--;
        }

        if (playerHp.hp <= 0)
        {
            GetComponent<PlayerDead>().Dead();
        }

    }

    //HPのダメージ表現
    void DamageLife(int damage)
    {

        int saveValue = damage;

        const float DAMAGETIME = 0.3f;

        for (int i = playerHp.hp - 1; damage > 0; damage--, i--)
        {
            if (i < 0) break;


            const float POW = 8f;
            StartCoroutine(MyLib.DoShake(
                DAMAGETIME, 
                POW,
                playerUI.lifeImage[i].transform));

        }


        StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        {
            DamageUpdate(saveValue);

        }));

    }

    void MatBlink()
    {
        if (IsDamage == false) return;

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
            IsDamage = false;
        }
    }
}

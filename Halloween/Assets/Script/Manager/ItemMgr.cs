using UnityEngine;

public class ItemMgr : Singleton<ItemMgr>
{
    public enum ItemType
    {
        heal,
        //gold,
        //stockHeal,
        //stockAttack,
        //stockDefence,
        //stockSpeed,
        //autoKey,
        //bomb,
        ////autoEfkLv1,
        ////autoEfkLv2,
        ////autoEfkLv3,
        //maxHeart,
        //swordF,
        //swordI,
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    //public ItemType type;

    [SerializeField] string itemHealSE= "Sound/SE/Item/02_Heal_02";

    public ItemType item;

    public string GetItemSe(ItemType t)
    {
        if(ItemType.heal==t)
        return itemHealSE;

        return null;
    }

    public void GetItemEffect(ItemType type,Transform trans)
    {
        if (ItemType.heal == type)
            trans.GetComponent<PlayerHp>().HealLife(1);

    }

    //public enum MatType
    //{
    //    //魔法アイテムなど追加3つぐらい
    //    PHM,//回復
    //    PAM,//攻撃
    //    PDM,//防御
    //    PSM,//速度
    //    MAGICGRAVITY, //引き寄せ
    //    MAGICSTAR,  //全体攻撃
    //    MAGICSHIELD,//守り＆攻撃
    //    //Rune_LV1,
    //    //Rune_LV2,
    //    //Rune_LV3,
    //    MAXH,
    //    None,
    //}


    //[SerializeField]Image[] useItemImage;
    //[SerializeField] int useItemNum = 0;

    //ParticleSystem atkParticle;//パーティクル
    //ParticleSystem defParticle;//パーティクル
    //ParticleSystem spdParticle;//パーティクル

    ////float atkTime;//継続時間　バフ
    ////float defTime;//継続時間　バフ
    ////float spdTime;//継続時間　バフ

    ////float atkTimeD;//継続時間　デバフ
    ////float defTimeD;//継続時間　デバフ
    ////float spdTimeD;//継続時間　デバフ


    //Material noneMat;
    //private void Start()
    //{
    //    noneMat = (Material)Resources.Load("UI/" + MatType.None.ToString());

    //    atkParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyFire Lvl 3");
    //    defParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyIce Lvl 3");
    //    spdParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyWater Lvl 3");

    //    //ロード選択されていたら
    //    if (Save.I.isLoad)
    //        Save.I.ItemLoad();

    //}

    //public string[] GetAllNames()
    //{
    //    string[] names=new string[4];

    //    int count = 0;
    //    foreach (var image in useItemImage)
    //    {
    //        names[count] = image.material.name;

    //        count++;
    //    }
    //    return names;
    //}

    //public void SetUseItem(ItemType item)
    //{
    //    if (ItemMax()) return;

    //    foreach(var image in useItemImage)
    //    {
    //        if(image.material.name == MatType.None.ToString())
    //        {
    //            if (item == ItemType.stockHeal)
    //                image.material = (Material)Resources.Load("UI/" + MatType.PHM.ToString());
    //            else if (item == ItemType.stockAttack)
    //                image.material = (Material)Resources.Load("UI/" + MatType.PAM.ToString());
    //            else if (item == ItemType.stockDefence)
    //                image.material = (Material)Resources.Load("UI/" + MatType.PDM.ToString());
    //            else if (item == ItemType.stockSpeed)
    //                image.material = (Material)Resources.Load("UI/" + MatType.PSM.ToString());

    //            break;
    //        }
    //    }

    //    useItemNum++;
    //}

    //public void UseItem(int num)
    //{
    //    if (useItemNum <= 0) return;


    //    var player = GameObject.FindGameObjectWithTag("Player");
    //    var paPos = player.transform.position;
    //    paPos.y += 0.5f;

    //    //プレイヤー回復
    //    if (useItemImage[num].material.name == MatType.PHM.ToString() && !player.GetComponent<PlayerHP>().IsHpMax())
    //    {
    //        const int healVal = 3;
    //        player.GetComponent<PlayerScr>().PlayerHeal(healVal);

    //        useItemImage[num].material = noneMat;
    //        useItemNum--;
    //    }
    //    else if(useItemImage[num].material.name == MatType.PAM.ToString())
    //    {
    //        var possible = TimeManager.I.SetTimerUseItem(useItemImage[num].material);

    //        //使用中のため使用できない
    //        if (!possible) return;
    //        Debug.Log("攻撃アップ効果");

    //        var pObj = Instantiate(atkParticle.gameObject, paPos, Quaternion.identity);
    //        pObj.transform.parent = player.transform;

    //        const int BATK = 10;
    //        player.GetComponent<PlayerScr>().atkParam += BATK;

    //        StartCoroutine(MyLib.DelayCoroutine(60f, () =>
    //        {

    //            player.GetComponent<PlayerScr>().atkParam -= BATK;
    //            Destroy(pObj);
    //            Debug.Log("攻撃アップ効果終了");

    //        }));



    //        const float volume = 0.15f;
    //        MyLib.MyPlayOneSound("SE/Item/02_Heal_02", volume, this.gameObject);

    //        useItemImage[num].material = noneMat;
    //        useItemNum--;
    //    }
    //    else if (useItemImage[num].material.name == MatType.PDM.ToString())
    //    {
    //        var possible = TimeManager.I.SetTimerUseItem(useItemImage[num].material);

    //        //使用中のため使用できない
    //        if (!possible) return;
    //        Debug.Log("防御アップ効果");


    //        var pObj = Instantiate(defParticle.gameObject, paPos, Quaternion.identity);
    //        pObj.transform.parent = player.transform;

    //        const int BDEF = 1;
    //        player.GetComponent<PlayerScr>().defParam += BDEF;

    //        StartCoroutine(MyLib.DelayCoroutine(60f, () =>
    //        {

    //            player.GetComponent<PlayerScr>().defParam -= BDEF;
    //            Destroy(pObj);
    //            Debug.Log("防御アップ効果終了");

    //        }));

    //        const float volume = 0.15f;
    //        MyLib.MyPlayOneSound("SE/Item/02_Heal_02", volume, this.gameObject);

    //        useItemImage[num].material = noneMat;
    //        useItemNum--;
    //    }
    //    else if (useItemImage[num].material.name == MatType.PSM.ToString())
    //    {
    //        var possible = TimeManager.I.SetTimerUseItem(useItemImage[num].material);

    //        //使用中のため使用できない
    //        if (!possible) return;

    //        Debug.Log("速度アップ効果");



    //        var pObj = Instantiate(spdParticle.gameObject, paPos, Quaternion.identity);
    //        pObj.transform.parent = player.transform;

    //        StartCoroutine(MyLib.DelayCoroutine(60f, () =>
    //        {

    //            player.GetComponent<PlayerScr>().SetSpeed(1f, 1f);
    //            Destroy(pObj);

    //            Debug.Log("速度アップ効果終了");

    //        }));

    //        const float MULTI= 1.25f;
    //        //プレイヤー速度アップ
    //        player.GetComponent<PlayerScr>().SetSpeed(MULTI, MULTI);


    //        const float volume = 0.15f;
    //        MyLib.MyPlayOneSound("SE/Item/02_Heal_02", volume, this.gameObject);

    //        useItemImage[num].material = noneMat;
    //        useItemNum--;
    //    }
    //}

    //public bool ItemMax()
    //{
    //    return useItemNum > 3;
    //}

    //アイテムが使用されたときに整列させる処理
}

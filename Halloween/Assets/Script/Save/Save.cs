using UnityEngine;

public class Save : Singleton<Save>
{
    //int playerItemNum = 0;


    //public void GoldLoad()
    //{
    //    ロード処理 お金
    //    var gold = PlayerPrefs.GetInt("GOLD", 0);
    //    GameObject.Find("GoldUI").GetComponent<GoldScr>().AddGold(gold);
    //}

    //public float GameTimeLoad()
    //{
    //    return PlayerPrefs.GetFloat("PLAYTIME",0);

    //}

    //public int GetHp()
    //{
    //    return PlayerPrefs.GetInt("HP", 3);
    //}

    //public int GetMaxHp()
    //{
    //    return PlayerPrefs.GetInt("MAXHP", 3);
    //}

    //public void ItemLoad()
    //{
    //    //var names = ItemMgr.I.GetAllNames();

    //    playerItemNum=PlayerPrefs.GetInt("PLAYEITEMNUM", 0);

    //    if (playerItemNum == 0) return;

    //    var names =new string[playerItemNum];
    //    for (int i = playerItemNum-1; i >= 0; i--)
    //    {
    //        var name = PlayerPrefs.GetString("PHMKey" + i.ToString(), "None");
    //        if (name != "None")
    //        {
    //            ItemMgr.I.SetUseItem(ItemMgr.ItemType.stockHeal);
    //            //names[i]= name;
    //            continue;
    //        }

    //        name = PlayerPrefs.GetString("PAMKey" + i.ToString(), "None");
    //        if (name != "None")
    //        {
    //            ItemMgr.I.SetUseItem(ItemMgr.ItemType.stockAttack);
    //            //names[i] = name;
    //            continue;
    //        }
    //        name = PlayerPrefs.GetString("PDMKey" + i.ToString(), "None");
    //        if (name != "None")
    //        {
    //            ItemMgr.I.SetUseItem(ItemMgr.ItemType.stockDefence);
    //            //names[i] = name;
    //            continue;
    //        }
    //        name = PlayerPrefs.GetString("PSMKey" + i.ToString(), "None");
    //        if (name != "None")
    //        {
    //            ItemMgr.I.SetUseItem(ItemMgr.ItemType.stockSpeed);
    //            //names[i] = name;
    //            continue;
    //        }
    //    }

    //}

    //void ItemSave()
    //{
    //    playerItemNum = 0;
    //    var names = ItemMgr.I.GetAllNames();
    //    foreach (var name in names)
    //    {
    //       if (name == "PHM")
    //        {
    //            PlayerPrefs.SetString("PHMKey" + playerItemNum.ToString(), "PHM" + playerItemNum.ToString());

    //            playerItemNum++;

    //        }
    //        else if (name == "PAM")
    //        {
    //            PlayerPrefs.SetString("PAMKey" + playerItemNum.ToString(), "PAM" + playerItemNum.ToString());

    //            playerItemNum++;

    //        }
    //        else if (name == "PDM")
    //        {
    //            PlayerPrefs.SetString("PDMKey" + playerItemNum.ToString(), "PDM" + playerItemNum.ToString());

    //            playerItemNum++;


    //        }
    //        else if (name == "PSM")
    //        {
    //            PlayerPrefs.SetString("PSMKey" + playerItemNum.ToString(), "PSM" + playerItemNum.ToString());

    //            playerItemNum++;

    //        }
    //    }

    //    PlayerPrefs.SetInt("PLAYEITEMNUM", playerItemNum);
    //}
    //アイテム
    //ステージNo
    //HP
    //MAXHP
    //プレイ時間の保存

    public bool isLoad;//タイトル画面でロードを選択し場合trueにする
    public bool isSceneChange = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    public void PlayerSave(Vector3 pos)
    {
        Debug.Log("保存した");

        //全部の　セーブの消去
        PlayerPrefs.DeleteAll();

        //PlayerPrefs.SetInt("STAGENO", stageNo);
        //PlayerPrefs.SetInt("GOLD", GameObject.Find("GoldUI").GetComponent<GoldScr>().GetGold());
        //ItemSave();

        //HP MAXHPセーブ
        var hpScr = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerHp>();
        //PlayerPrefs.SetInt("HP", hpScr.hp);
        //PlayerPrefs.SetInt("MAXHP", hpScr.MAXHP);


        //プレイ時間の保存
        //PlayerPrefs.SetFloat("PLAYTIME", GameObject.Find("GameTimer").GetComponent<GameTimerOriginal>().deltaTime);

        PlayerPrefs.SetFloat("POSX", pos.x);
        PlayerPrefs.SetFloat("POSY", pos.y);
        PlayerPrefs.SetFloat("POSZ", pos.z);

        //PlayerPrefs.SetString("SCENENAME", SceneManager.GetActiveScene().name);
        //セーブ処理
        PlayerPrefs.Save();
    }

    public void PlayerHpSave()
    {
        Debug.Log("HP保存");


        //HP MAXHPセーブ
        var hpScr = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerHp>();
        PlayerPrefs.SetInt("HP", hpScr.hp);


        //セーブ処理
        PlayerPrefs.Save();
        isSceneChange = true;
    }

}

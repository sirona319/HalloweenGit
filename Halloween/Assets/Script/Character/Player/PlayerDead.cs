using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    //[SerializeField] Transform DeadSprite;

    ////移動させる画像
    //[SerializeField] Image eyeImageUp;
    //[SerializeField] Image eyeImageDown;
    ////

    //[SerializeField] Transform closeEyeImageUp1;
    //[SerializeField] Transform closeEyeImageDown1;
    //[SerializeField] Transform closeEyeImageUp2;
    //[SerializeField] Transform closeEyeImageDown2;
    //[SerializeField] Transform closeEyeImageUp0;
    //[SerializeField] Transform closeEyeImageDown0;

    //[SerializeField] Transform EyeObj;
    //[SerializeField] TextMeshProUGUI reviveText;


    //const string eyeNameUp0 = "up0";
    //const string eyeNameDown0 = "down0";

    //const string eyeNameUp1 = "up1";
    //const string eyeNameDown1 = "down1";
    //const string eyeNameUp2 = "up2";
    //const string eyeNameDown2 = "down2";

    //const string eyeNameUpReal = "EyeUp";
    //const string eyeNameDownReal = "EyeDown";

    //const string eyeNameDownRealText = "ReviveText";


    PlayerUI playerUI;


    private void Start()
    {
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();

        playerUI.EyeObj.gameObject.SetActive(false);

    }

    #region 死亡時
    public void CloseEye1()
    {
        playerUI.EyeObj.gameObject.SetActive(true);
        playerUI.DeadSprite.gameObject.SetActive(true);
        playerUI.eyeImageUp.transform.DOMove(playerUI.closeEyeImageUp1.position, 1f);
        playerUI.eyeImageDown.transform.DOMove(playerUI.closeEyeImageDown1.position, 1f);
    }

    public void CloseEye2()
    {
        playerUI.eyeImageUp.transform.DOMove(playerUI.closeEyeImageUp2.position, 1f);
        playerUI.eyeImageDown.transform.DOMove(playerUI.closeEyeImageDown2.position, 1f);

        playerUI.reviveText.DOFade(endValue: 1f, duration: 2f);

        StartCoroutine(MyLib.DelayCoroutine(1f, () =>
        {
            DeadPosLoad();
        }));
    }

    #endregion

    #region 復活時
    public void OpenEye0()
    {
        playerUI.eyeImageUp.transform.DOMove(playerUI.closeEyeImageUp0.position, 1f);
        playerUI.eyeImageDown.transform.DOMove(playerUI.closeEyeImageDown0.position, 1f);
    }

    public void OpenEye1()
    {
        playerUI.eyeImageUp.transform.DOMove(playerUI.closeEyeImageUp1.position, 1f);
        playerUI.eyeImageDown.transform.DOMove(playerUI.closeEyeImageDown1.position, 1f);
    }

    public void OpenEye2()
    {
        playerUI.eyeImageUp.transform.DOMove(playerUI.closeEyeImageUp2.position, 1f);
        playerUI.eyeImageDown.transform.DOMove(playerUI.closeEyeImageDown2.position, 1f);

        playerUI.reviveText.DOFade(endValue: 0f, duration: 1f);
    }
    #endregion
    public void DeadPosLoad()
    {
        //if (Save.I.isLoad)
        //{
        Vector3 loadPos;
        loadPos.x = PlayerPrefs.GetFloat("POSX");
        loadPos.y = PlayerPrefs.GetFloat("POSY");
        loadPos.z = PlayerPrefs.GetFloat("POSZ");
        transform.position = loadPos;
        //}

        GetComponent<PlayerScr2D>().isDead = false;
        GetComponent<Animator>().SetBool("dead", false);

        GetComponent<PlayerHp>().HealLife(3);


        //敵のリスポーン　破棄して　生成？
        foreach (var obj in GameObject.FindGameObjectsWithTag(TagName.Spawn))
        {
            obj.GetComponent<BaseSpawn>().DeadNotice();
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }
}

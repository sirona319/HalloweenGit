using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] Transform DeadSprite;

    //移動させる画像
    [SerializeField] Image eyeImageUp;
    [SerializeField] Image eyeImageDown;
    //

    [SerializeField] Image closeEyeImageUp1;
    [SerializeField] Image closeEyeImageDown1;
    [SerializeField] Image closeEyeImageUp2;
    [SerializeField] Image closeEyeImageDown2;
    [SerializeField] Image closeEyeImageUp0;
    [SerializeField] Image closeEyeImageDown0;
    [SerializeField] TextMeshProUGUI reviveText;

    [SerializeField] Transform EyeObj;


    const string eyeNameUp0 = "up0";
    const string eyeNameDown0 = "down0";

    const string eyeNameUp1 = "up1";
    const string eyeNameDown1 = "down1";
    const string eyeNameUp2 = "up2";
    const string eyeNameDown2 = "down2";

    const string eyeNameUpReal = "EyeUp";
    const string eyeNameDownReal = "EyeDown";

    const string eyeNameDownRealText = "ReviveText";

    private void Start()
    {

        eyeImageUp = EyeObj.Find(eyeNameUpReal).GetComponent<Image>();
        eyeImageDown = EyeObj.Find(eyeNameDownReal).GetComponent<Image>();


        closeEyeImageUp0 = DeadSprite.Find(eyeNameUp0).GetComponent<Image>();
        closeEyeImageDown0 = DeadSprite.Find(eyeNameDown0).GetComponent<Image>();
        closeEyeImageUp1 = DeadSprite.Find(eyeNameUp1).GetComponent<Image>();
        closeEyeImageDown1 = DeadSprite.Find(eyeNameDown1).GetComponent<Image>();
        closeEyeImageUp2 = DeadSprite.Find(eyeNameUp2).GetComponent<Image>();
        closeEyeImageDown2 = DeadSprite.Find(eyeNameDown2).GetComponent<Image>();

        reviveText = EyeObj.Find(eyeNameDownRealText).GetComponent<TextMeshProUGUI>();

        EyeObj.gameObject.SetActive(false);
        //DeadSprite.gameObject.SetActive(false);

    }

    #region 死亡時
    public void CloseEye1()
    {
        EyeObj.gameObject.SetActive(true);
        DeadSprite.gameObject.SetActive(true);
        eyeImageUp.transform.DOMove(closeEyeImageUp1.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown1.transform.position, 1f);
    }

    public void CloseEye2()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp2.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown2.transform.position, 1f);

        reviveText.DOFade(endValue: 1f, duration: 2f);

        StartCoroutine(MyLib.DelayCoroutine(1f, () =>
        {
            DeadPosLoad();
        }));
    }

    #endregion

    #region 復活時
    public void OpenEye0()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp0.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown0.transform.position, 1f);
    }

    public void OpenEye1()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp1.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown1.transform.position, 1f);
    }

    public void OpenEye2()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp2.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown2.transform.position, 1f);

        reviveText.DOFade(endValue: 0f, duration: 1f);
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
            obj.GetComponent<BaseSpawn>().DeadTest();
        }
    }


    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }
}

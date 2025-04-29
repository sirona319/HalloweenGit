using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    //移動させる画像
    public Image eyeImageUp;
    public Image eyeImageDown;
    //

    public Image closeEyeImageUp1;
    public Image closeEyeImageDown1;
    public Image closeEyeImageUp2;
    public Image closeEyeImageDown2;
    public Image closeEyeImageUp0;
    public Image closeEyeImageDown0;
    public TextMeshProUGUI reviveText;

    #region 死亡時
    public void CloseEye1()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp1.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown1.transform.position, 1f);
    }

    public void CloseEye2()
    {
        eyeImageUp.transform.DOMove(closeEyeImageUp2.transform.position, 1f);
        eyeImageDown.transform.DOMove(closeEyeImageDown2.transform.position, 1f);

        reviveText.DOFade(endValue: 1f, duration: 1f);

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
    }


    private void OnDestroy()
    {
        DOTween.Kill(this);
        //DOTween.KillAll();
        Debug.Log("BounceDOTrans Destroy");
    }
}

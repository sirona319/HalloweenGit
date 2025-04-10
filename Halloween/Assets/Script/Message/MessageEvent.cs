using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageEvent : MonoBehaviour
{
    const float fadeSpeed = 1;
    [SerializeField] Image readIcon;
    [SerializeField] TextMeshProUGUI messageUI;


    #region　アニメーションイベント

    public void MessageStart()
    {
        messageUI.enabled = true;
        readIcon.enabled = true;
        var TextBack = transform.GetChild(0).GetComponent<Image>();
        transform.GetChild(0).GetComponent<Image>().enabled = true;


        const float targetAlpha = 0.7f;
        var tColor = TextBack.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        TextBack.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);

    }

    public void MessageEnd()
    {
        messageUI.enabled = false;
        readIcon.enabled = false;
        var TextBack = transform.GetChild(0).GetComponent<Image>();


        const float targetAlpha = 0;
        var tColor = TextBack.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        TextBack.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);

        //プレイヤーの移動制限解除
        var p = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>();
        p.isLimitMove = false;
        p.moveSpeed = p.maxMoveSpeed;

    }

    #endregion
}

using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageEvent : MonoBehaviour
{
    const float fadeSpeed = 1;
    [SerializeField] Image textBackImage;
    [SerializeField] Image readIcon;
    [SerializeField] TextMeshProUGUI messageUI;

    #region　アニメーションイベント

    public void MessageStart()
    {
        messageUI.enabled = true;
        readIcon.enabled = true;
        textBackImage.enabled = true;


        const float targetAlpha = 0.7f;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);

    }

    public void MessageEnd()
    {
        messageUI.enabled = false;
        readIcon.enabled = false;


        const float targetAlpha = 0;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);

        //プレイヤーの移動制限解除
        var p = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>();
        p.isLimitMove = false;
        p.moveSpeed = p.maxMoveSpeed;

    }

    #endregion
}

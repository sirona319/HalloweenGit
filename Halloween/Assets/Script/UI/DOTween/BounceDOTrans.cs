using DG.Tweening;
using UnityEngine;

public class BounceDOTrans : MonoBehaviour
{
    Transform trans;

    [SerializeField] float duration = 0.4f;
    [SerializeField] float moveY = 20f;
    //[SerializeField] int loopTime = -1;

    void Awake()
    {
        trans = GetComponent<Transform>();
        StartNewRecordAnim();
    }

    void StartNewRecordAnim()
    {
        trans.DOLocalMoveY(moveY, duration)
        .SetRelative(true)
        .SetEase(Ease.OutQuad)
        .SetLoops(-1, LoopType.Yoyo);
    }
}

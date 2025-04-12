using UnityEngine;
using UnityEngine.UI;

public class GameStartEvent : MonoBehaviour, IHaveText
{
    //[SerializeField] GameObject player;

    public TimelineControl[] timelineTexts;
    int timelineNo = 0;

    [SerializeField] GameObject player;
    [SerializeField] Image eventBack;
    public void TextReadPlus()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        //timelineNo++;
    }

    #region シグナル

    public void SignalDisabelImage()
    {

        eventBack.enabled = false;

        //timelineTexts[timelineNo].isPlayTrigger = true;
        //timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();

    }
    public void SignalPlayerActive()
    {

        player.GetComponent<Animator>().SetTrigger("tStart");

        //timelineTexts[timelineNo].isPlayTrigger = true;
        //timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();

    }

    #endregion
}

﻿using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class GameStartEvent : MonoBehaviour, IHaveText
{
    [SerializeField] GameObject player;

    public TimelineControl[] timelineTexts;
    int timelineNo = 0;


    void Awake()
    {
        player.GetComponent<PlayerMove>().isStartPos = true;

    }
    void Start()
    {

        GameObject.FindGameObjectWithTag("SoundM").GetComponent<AudioSource>().Stop();

        var isEvent = GameObject.FindGameObjectWithTag(TagName.GameController).GetComponent<GManager>().isStartEventEnable;

        if (!isEvent)
        {
            timelineTexts[0].gameObject.SetActive(false);
        }
    }
    //[SerializeField] GameObject player;
    //[SerializeField] Image eventBack;
    public void TextReadPlus()
    {
        timelineTexts[timelineNo].isPlayTrigger = true;
        //timelineNo++;
    }

    #region シグナル

    //public void SoundMgrActive()
    //{
    //    GameObject.FindGameObjectWithTag("SoundM").GetComponent<AudioSource>().Play();
    //}

    public void EndEvent()
    {
        GameObject.FindGameObjectWithTag("SoundM").GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag(TagName.GameController).GetComponent<GManager>().isStartEventEnable = false;
    }

    //public void SignalDisabelImage()
    //{
    //    Debug.Log("SignalDisabelImage");
    //    //eventBack.enabled = false;

    //    //timelineTexts[timelineNo].isPlayTrigger = true;
    //    //timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();

    //}
    //public void SignalPlayerActive()
    //{
    //    Debug.Log("SignalPlayerActive");
    //    //player.GetComponent<Animator>().SetTrigger("tStart");

    //    //timelineTexts[timelineNo].isPlayTrigger = true;
    //    //timelineTexts[0].GetComponentInChildren<BossCollisionTrigger>().BossCollisionOff();

    //}

    #endregion
}

﻿using UnityEngine;
using static FadeScene;

public class DoorScene : MonoBehaviour
{
    [SerializeField] SceneNameType SceneName;
    [SerializeField] Vector3 playerToPos;
    //int playerHp = 0;

    bool isDoorOpen = false;

    bool isDisable = false;
    // Update is called once per frame
    void Update()
    {
        if (isDisable) return;

        if (!isDoorOpen) return;

        if (!Input.GetKeyDown(KeyCode.W)) return;

        DoorSceneEnter();

    }

    void DoorSceneEnter()
    {
        //isDoorOpen = false;


        var seAudio = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        MyLib.MyPlayOneSound("Sound/SE/wave/決定ボタンを押す12", 1f, seAudio);

        var gMgr = GameObject.FindGameObjectWithTag(TagName.GameController).GetComponent<GManager>();
        gMgr.playerPos = playerToPos;
        gMgr.isChangePlayer = true;
        gMgr.playerHp = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerHp>().hp;


        //シーン遷移　プレイヤー座標の設定　効果音　プレイヤーのみと分ける
        const float sceneChangeTime = 2f;
        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().SceneFade
            (SceneName.ToString(), 0f, sceneChangeTime);

        isDisable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDoorOpen) return;
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = false;
        }
    }
}

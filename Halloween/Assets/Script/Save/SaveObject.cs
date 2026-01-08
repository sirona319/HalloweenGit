using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using static ItemMgr;

public class SaveObject : MonoBehaviour
{
    [SerializeField] ParticleSystem savePa;

    [SerializeField] Transform movePoint;

    [SerializeField] Vector3 savePos;
    [SerializeField] float saveY=1;

    // Start is called before the first frame update
    void Start()
    {
        if(savePa!=null)
        savePa.Stop();

        savePos = transform.position;
        savePos.y += saveY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(TagName.Player))
        {
            //敵のリセット
            //SpawnManager.I.ResetSpawns();

            //回復
            //const int healVal = 3;
            //other.GetComponent<PlayerScr2D>().PlayerHeal(healVal);

            //パーティクル
            if (savePa != null)
                savePa.Play();

            //セーブ
            var SaveMgr = GameObject.FindGameObjectWithTag(TagName.SaveM).GetComponent<Save>();
            SaveMgr.PlayerSave(savePos);

            const float volume = 0.1f;

            MyLib.MyPlayOneSound(ItemMgr.I.GetItemSe(ItemMgr.ItemType.heal), volume, gameObject);

            const float fadeEndTime = 2f;
            const float sceneChangeEndTime = 2f;//次の遷移が可能になるまで
            //転送位置があるかどうか
            if (movePoint != null)
                GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().PlayerMoveTarget(movePoint.position, fadeEndTime, sceneChangeEndTime);
            //other.transform.position = movePoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.CompareTag(TagName.Player))
        {
            //回復
            const int healVal = 3;
            other.transform.GetComponent<PlayerHp>().HealLife(healVal);
            const float volume = 0.1f;
            var itemMgr = GameObject.FindGameObjectWithTag("ItemMgr").GetComponent<ItemMgr>();
            MyLib.MyPlayOneSound(
                itemMgr.GetItemSe((ItemType)Enum.ToObject(typeof(ItemType), ItemType.heal)),
                volume, 
                gameObject);

            //パーティクル
            //if (savePa != null)
            //    savePa.Play();

            //セーブ
            var SaveMgr = GameObject.FindGameObjectWithTag(TagName.SaveM).GetComponent<Save>();
            SaveMgr.PlayerSave(savePos);

            const float fadeEndTime = 2f;
            const float sceneChangeEndTime = 2f;//次の遷移が可能になるまで
            //転送位置があるかどうか
            if (movePoint != null)
                GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().PlayerMoveTarget(movePoint.position, fadeEndTime, sceneChangeEndTime);
            //other.transform.position = movePoint.position;
        }

    }

    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.transform.CompareTag("Player"))
    //    {
    //        //パーティクル止める
    //        if (savePa != null)
    //            savePa.Stop();


    //    }

    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        Save.I.PlayerSave();
    //    }
    //}
}

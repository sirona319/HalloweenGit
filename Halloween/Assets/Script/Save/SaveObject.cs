using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    //void Update()
    //{
        
    //}

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
            Save.I.PlayerSave(savePos);

            const float volume = 0.1f;
            MyLib.MyPlayOneSound("SE/Item/" + "02_Heal_02", volume, this.gameObject);

            //転送位置があるかどうか
            if (movePoint != null)
                GManager.I.PlayerMoveTarget(movePoint.position);
            //other.transform.position = movePoint.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
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
            Save.I.PlayerSave(savePos);

            //const float volume = 0.1f;
            //MyLib.MyPlayOneSound("SE/Item/" + "02_Heal_02", volume, this.gameObject);

            //転送位置があるかどうか
            if (movePoint != null)
                GManager.I.PlayerMoveTarget(movePoint.position);
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

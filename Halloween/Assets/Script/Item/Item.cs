using UnityEngine;
using static ItemMgr;

public class Item : MonoBehaviour
{
    ItemMgr itemMgr;
    [SerializeField] ItemType type;

    [SerializeField] float seVolume = 1;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if (eraseTime > 0) return;//存在時間

    //    // if (isGet) return;//

    //    if (!collision.gameObject.transform.CompareTag(TagName.Player))
    //            return;

    //        //const float volume = 0.3f;
    //        //bool isDead = false;
    //        //string itemName = "";
    //        //if (type == ItemType.heal)
    //        //{
    //        //回復音　サウンド

    //        //itemName = "02_Heal_02";


    //        //collision.transform.GetComponent<PlayerHp>().HealLife(1);
    //    ItemMgr.I.GetItemEffect(type, collision.transform);
    //    //const float volume = 0.3f;
    //    MyLib.MyPlayOneSound(ItemMgr.I.GetItemSe(type), seVolume, ItemMgr.I.gameObject);
    //    this.gameObject.SetActive(false);
    //    // }

    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.gameObject.transform.CompareTag(TagName.Player))return;

    //    ItemMgr.I.GetItemEffect(type, collision.transform);

    //    MyLib.MyPlayOneSound(ItemMgr.I.GetItemSe(type), seVolume, ItemMgr.I.gameObject);
    //    this.gameObject.SetActive(false);

    //}

    void Start()
    {
        itemMgr = GameObject.FindWithTag("ItemMgr").GetComponent<ItemMgr>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag(TagName.Player)) return;


        itemMgr.GetItemEffect(type, collision.transform);
        MyLib.MyPlayOneSound(itemMgr.GetItemSe(type), seVolume, gameObject);


        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

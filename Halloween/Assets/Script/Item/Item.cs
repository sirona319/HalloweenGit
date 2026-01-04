using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemManager.ItemType type;

    [SerializeField] float seVolume = 0.3f;

    private void OnCollisionEnter(Collision collision)
    {
        //if (eraseTime > 0) return;//存在時間

        // if (isGet) return;//

        if (!collision.gameObject.transform.CompareTag(TagName.Player))
                return;

            //const float volume = 0.3f;
            //bool isDead = false;
            //string itemName = "";
            //if (type == ItemType.heal)
            //{
            //回復音　サウンド

            //itemName = "02_Heal_02";


            //collision.transform.GetComponent<PlayerHp>().HealLife(1);
        ItemManager.I.GetItemEffect(type, collision.transform);
        //const float volume = 0.3f;
        MyLib.MyPlayOneSound(ItemManager.I.GetItemSe(type), seVolume, ItemManager.I.gameObject);
        this.gameObject.SetActive(false);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.transform.CompareTag(TagName.Player))return;

        ItemManager.I.GetItemEffect(type, collision.transform);

        MyLib.MyPlayOneSound(ItemManager.I.GetItemSe(type), seVolume, ItemManager.I.gameObject);
        this.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.transform.CompareTag(TagName.Player)) return;

        ItemManager.I.GetItemEffect(type, collision.transform);

        MyLib.MyPlayOneSound(ItemManager.I.GetItemSe(type), seVolume, gameObject);
        this.gameObject.SetActive(false);
    }
}

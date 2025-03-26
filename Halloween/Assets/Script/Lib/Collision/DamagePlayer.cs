using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] int damageVal = 1;
    //public IDamage damage;
    //public bool isActiveTrigger = false;

    //タイムライン再生用の関数
    //public void SetTimeline(bool act)
    //{
    //    if (transform.parent.GetComponent<TimelineControl>() == null)return;

    //    transform.parent.GetComponent<TimelineControl>().isPlayTrigger = act;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        var iDamage = other.transform.GetComponent<IDamage>();
    //        if (iDamage != null)
    //            iDamage.Damage(1);
    //        //isActiveTrigger = true;
    //        // SetTimeline(true);
    //        Debug.Log(other.name);

    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player) /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        //isActiveTrigger = false;
    //       /// SetTimeline(false);
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagName.Player))return;
        
        var iDamage = other.GetComponent<IDamage>();
        if (iDamage != null)
        {
            iDamage.Damage(damageVal);
            MyLib.MyPlaySound("Sound/SE/wave/damaged1", 0.5f, SoundManager.I.transform.GetChild(0).gameObject);

            //MyLib.MyPlayOneSound("Sound/SE/wave/damaged1", 0.5f, SoundManager.I.transform.GetChild(0).gameObject);
            //isActiveTrigger = true;
            // SetTimeline(true);
            //Debug.Log(other.name);
        }

        

    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.CompareTag(TagName.Player) /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        //isActiveTrigger = false;
    //        // SetTimeline(false);
    //        Debug.Log(other.name);
    //    }

    //}
}

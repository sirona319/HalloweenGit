using UnityEngine;
using UnityEngine.Audio;

public class BossCollisionTrigger : MonoBehaviour
{
    public float cameraDuration;
    public Vector3 cameraBossPos;

    public BoxCollider2D[] boxs2D;

    public GameObject bossPumpkin;

    public bool isBossBattle = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        //if (isBossBattle) return;
        if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            foreach(var i in boxs2D)
            {
                foreach(var j in i.GetComponents<BoxCollider2D>())
                {
                    j.enabled = true;
                }
            }



            Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraBossPos, cameraDuration);

            //var readText = bossPumpkin.GetComponent<IHaveText>();
            //if (readText != null)
            //    readText.TextReadPlus();

            //isBossBattle = true;

            bossPumpkin.GetComponent<PumpkinBossScr>().BattleStart(true);
        }

    }

    //
    public void BossCollisionOff()
    {
        foreach (var i in boxs2D)
        {
            foreach (var j in i.GetComponents<BoxCollider2D>())
            {
                j.enabled = false;
            }
        }

        var readText = bossPumpkin.GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();

        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

}

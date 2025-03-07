using UnityEngine;
using UnityEngine.Audio;

public class BossCollisionTrigger : MonoBehaviour
{
    public float cameraDuration;
    public Vector3 cameraBossPos;

    public BoxCollider2D[] boxs2D;

    public BoxCollider2D ereaCol; 

    public BoxCollider2D box2DLeft;
    public BoxCollider2D box2DRight;
    public BoxCollider2D box2DUp;
    public BoxCollider2D box2DDown;

    //public BoxCollider box3DLeft;
    //public BoxCollider box3DRight;
    //public BoxCollider box3DUp;
    //public BoxCollider box3DDown;

    public GameObject haveTextObject;

    public bool isBossBattle = false;

    public GameObject DEBUGBOSSFLG;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraBossPos, cameraDuration);

    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {

    //    }

    //}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (isBossBattle) return;
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            foreach(var i in boxs2D)
            {
                foreach(var j in i.GetComponents<BoxCollider2D>())
                {
                    j.enabled = true;
                }
            }
            //ereaCol.enabled = true;
            //box2DLeft.enabled = true;
            //box2DRight.enabled = true;
            //box2DUp.enabled = true;
            //box2DDown.enabled = true;



            Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraBossPos, cameraDuration);

            //var readText = haveTextObject.GetComponent<IHaveText>();
            //if (readText != null)
            //    readText.TextReadPlus();

            isBossBattle = true;

            DEBUGBOSSFLG.GetComponent<PumpkinBossScr>().BattleStart(true);
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

        //ereaCol.enabled = false;

        //box2DLeft.enabled = false;
        //box2DRight.enabled = false;
        //box2DUp.enabled = false;
        //box2DDown.enabled = false;

        var readText = haveTextObject.GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();

        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {

    //    }

    //}
}

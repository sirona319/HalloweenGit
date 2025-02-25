using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour
{
    public float cameraDuration;
    public Vector3 cameraBossPos;

    public BoxCollider2D ereaCol; 

    public BoxCollider2D box2DLeft;
    public BoxCollider2D box2DRight;
    public BoxCollider box3DLeft;
    public BoxCollider box3DRight;
    public BoxCollider box3DUp;
    public BoxCollider box3DDown;

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

            ereaCol.enabled = true;
            box2DLeft.enabled = true;
            box2DRight.enabled = true;

            box3DLeft.enabled = true;
            box3DRight.enabled = true;
            box3DUp.enabled = true;
            box3DDown.enabled = true;

            Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraBossPos, cameraDuration);

            //var readText= haveTextObject.GetComponent<IHaveText>();
            //if (readText != null)
            //    readText.TextReadPlus();

            isBossBattle = true;

            DEBUGBOSSFLG.GetComponent<PumpkinBossScr>().BattleStart(true);
        }


    }

    //
    public void BossCollisionOff()
    {
        ereaCol.enabled = false;

        box2DLeft.enabled = false;
        box2DRight.enabled = false;

        box3DLeft.enabled = false;
        box3DRight.enabled = false;
        box3DUp.enabled = false;
        box3DDown.enabled = false;
        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {

    //    }

    //}
}

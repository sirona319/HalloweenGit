using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour
{
    public float cameraDuration;
    public Vector3 cameraBossPos;

    public BoxCollider2D box2DLeft;
    public BoxCollider2D box2DRight;

    public GameObject haveTextObject;
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
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {

            Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraBossPos, cameraDuration);
            box2DLeft.enabled = true;
            box2DRight.enabled = true;

            var readText= haveTextObject.GetComponent<IHaveText>();
            if (readText != null)
                readText.TextReadPlus();
            
        }


    }

    //
    public void BossCollisionOff()
    {
        box2DLeft.enabled = false;
        box2DRight.enabled = false;
        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {

    //    }

    //}
}

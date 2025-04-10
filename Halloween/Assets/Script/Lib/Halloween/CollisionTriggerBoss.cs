using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour
{
    [SerializeField] float cameraDuration;
    [SerializeField] Transform cameraSetTrans;

    [SerializeField] BoxCollider2D[] boxs2D;

    [SerializeField] GameObject bossPumpkin;
    bool isBossBattle = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (isBossBattle) return;

        if (!other.transform.CompareTag(TagName.Player)) return;
        
        isBossBattle = true;


        foreach (var i in boxs2D)
        {
            foreach(var j in i.GetComponents<BoxCollider2D>())
            {
                j.enabled = true;
            }
        }



        Camera.main.GetComponent<CameraControl>().CameraEventTrigger(cameraSetTrans.position, cameraDuration);

        var readText = bossPumpkin.GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();


        //デバッグ用 シグナルで呼んでいる　
        //bossPumpkin.GetComponent<PumpkinBossScr>().BattleStart(true);
        

    }

    //
    public void BossCollisionOff()
    {
        isBossBattle = false;

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

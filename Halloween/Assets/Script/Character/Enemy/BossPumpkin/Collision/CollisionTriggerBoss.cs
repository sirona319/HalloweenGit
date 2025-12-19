using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour
{
    [SerializeField] GameObject DEBUGbossPumpkin;

    [SerializeField] float cameraDuration;
    [SerializeField] Transform cameraSetTrans;

    [SerializeField] BoxCollider2D[] boxs2D;

    [SerializeField] GameObject boss;
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




        //デバッグ用 シグナルで呼んでいる　
        //DEBUGbossPumpkin.GetComponent<PumpkinBossScr>().SignalBattleState(true);
        //return;
        ///////////////////

        var readText = boss.GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();
    }

    //
    public void BossCollisionOff()
    {
        //isBossBattle = false;

        //コリジョンの無効
        foreach (var i in boxs2D)
        {
            foreach (var j in i.GetComponents<BoxCollider2D>())
            {
                j.enabled = false;
            }
        }

        //ボスの死亡会話？
        var readText = boss.GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();

        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

}

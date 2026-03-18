using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour
{
    //[SerializeField] GameObject DEBUGbossPumpkin;

    [SerializeField] float cameraDuration;
    [SerializeField] Transform cameraSetTrans;

    [SerializeField] BoxCollider2D[] boxs2D;

    //[SerializeField] GameObject boss;
    [SerializeField] bool isBossBattle = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (isBossBattle) return;

        if (!other.transform.CompareTag("Player")) return;
        
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
        var bPumpkin = GameObject.FindGameObjectWithTag("BossPumpkin");
        //bPumpkin.GetComponent<PumpkinBossScr>().SignalBattleState(true);

        //return;
        ///////////////////
        var readText = bPumpkin.GetComponent<IHaveText>();

        if (readText != null)
            readText.TextReadPlus();
    }

    //
    public void BossCollisionOffWin()
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
        var readText = GameObject.FindGameObjectWithTag("BossPumpkin").GetComponent<IHaveText>();
        if (readText != null)
            readText.TextReadPlus();

        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }

    public void BossCollisionOffLosePlayer()
    {
        isBossBattle = false;

        //コリジョンの無効
        foreach (var i in boxs2D)
        {
            foreach (var j in i.GetComponents<BoxCollider2D>())
            {
                j.enabled = false;
            }
        }

        Camera.main.GetComponent<CameraControl>().isEventCamera = false;
    }




    public void TimelinePumpkin()
    {
        var bPumpkin = GameObject.FindGameObjectWithTag("BossPumpkin");
        bPumpkin.GetComponent<PumpkinBossScr>().SignalBattleState(true);
    }
}



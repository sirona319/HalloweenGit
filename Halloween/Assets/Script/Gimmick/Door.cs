using UnityEngine;
using UnityEngine.SceneManagement;
using static FadeScene;

public class Door : MonoBehaviour
{
    //[SerializeField] SceneNameType SceneName;
    [SerializeField] Vector3 playerToPos;
    //int playerHp = 0;

    bool isDoorOpen = false;

    bool isDisable = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDoorOpen) return;

        if (!Input.GetKeyDown(KeyCode.W)) return;

        DoorMoveEnter();
    }
   

    void DoorMoveEnter()
    {
        var seAudio = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        MyLib.MyPlayOneSound("Sound/SE/wave/決定ボタンを押す12", 1f, seAudio);
        //シーン遷移　プレイヤー座標の設定　効果音　プレイヤーのみと分ける
        const float sceneChangeTime = 2f;
        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().PlayerMoveTarget(playerToPos,2f, sceneChangeTime);

        isDoorOpen = false;

        isDisable = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isDoorOpen)return;
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoorOpen = false;
        }
    }
}

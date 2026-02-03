using UnityEngine;
using static FadeScene;

public class DoorScene : MonoBehaviour
{
    [SerializeField] SceneNameType SceneName;
    [SerializeField] Vector3 playerToPos;

    bool isDoorOpen = false;

    bool isDisable = false;
    // Update is called once per frame
    void Update()
    {
        if (isDisable) return;

        if (!isDoorOpen) return;

        if (!Input.GetKeyDown(KeyCode.W)) return;

        DoorSceneEnter();

    }

    void DoorSceneEnter()
    {

        var seAudio = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        MyLib.MyPlayOneSound("Sound/SE/wave/決定ボタンを押す12", 1f, seAudio);

        var SaveMgr = GameObject.FindGameObjectWithTag(TagName.SaveM).GetComponent<Save>();
        SaveMgr.PlayerHpSave();

        //シーン遷移　プレイヤー座標の設定　効果音　プレイヤーのみと分ける
        const float sceneChangeTime = 2f;
        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().SceneFade
            (SceneName.ToString(), 0f, sceneChangeTime);

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
        if (isDoorOpen) return;
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

using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapLightGround : MonoBehaviour
{
    bool playerFall = false;

    [Tooltip("キャラクターと接触時 非アクティブ化する時間")]
    [HeaderAttribute("キャラクターと接触時 非アクティブ化する時間")]
    [SerializeField] float tileDisableTime = 0.3f;
    private void Update()
    {
        if (!playerFall) return;

        if(Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<TilemapCollider2D>().enabled = false;

            StartCoroutine(MyLib.DelayCoroutine(tileDisableTime, () =>
            {
                GetComponent<TilemapCollider2D>().enabled = true;
            }));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            playerFall = true;
            Debug.Log("LitghtGround");

        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            playerFall = false;
            Debug.Log("LitghtGround");

        }

    }
}

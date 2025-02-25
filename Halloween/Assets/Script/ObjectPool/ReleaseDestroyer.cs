using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ReleaseDestroyer : MonoBehaviour
{

    public PoolControl pool { get; set; }

    const float DESTIME = 7f;

    public bool IsRelease = false;

    public void PoolDestroy()
    {
        if (pool != null)
        {
            if (IsRelease)
            {
                //Debug.Log("二重リリース回避");
                return;
            }

            IsRelease = true;
            pool.ReleaseGameObject(gameObject);
            return;

        }
        else
        {

            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            var iDamage = other.transform.GetComponent<IDamage>();
            if (iDamage != null)
                iDamage.Damage(1);
            else
                Debug.Log("ダメージインターフェイスが無いよ！！Enemy");

                //Debug.Log("攻撃が敵にHIT");
            PoolDestroy();
            return;
        }

        if (other.CompareTag("EnemyBoss"))
        {
            var iDamage = other.transform.parent.parent.GetComponent<IDamage>();
            if (iDamage != null)
                iDamage.Damage(1);
            else
                Debug.Log("ダメージインターフェイスが無いよ！！EnemyBoss");

            //Debug.Log("攻撃が敵にHITBOSS");
            PoolDestroy();
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("ExitErea"))
        {
            PoolDestroy();
            return;
        }

    }
}
using UnityEngine;

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

        if (other.CompareTag(TagName.Enemy))
        {
            var iDamage = other.GetComponent<IDamage>();
            if (iDamage != null)
                iDamage.Damage(1);
            else
                Debug.Log("ダメージインターフェイスが無いよ！！"+TagName.Enemy);

                //Debug.Log("攻撃が敵にHIT");
            PoolDestroy();
            return;
        }

        if (other.CompareTag(TagName.EnemyBoss))
        {
            var iDamage = other.GetComponent<IDamage>();
            if (iDamage != null)
                iDamage.Damage(1);
            else
                Debug.Log("ダメージインターフェイスが無いよ！！EnemyBoss"+TagName.EnemyBoss);

            //Debug.Log("攻撃が敵にHITBOSS");
            PoolDestroy();
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag(TagName.ExitErea))
        {
            PoolDestroy();
            return;
        }

    }
}
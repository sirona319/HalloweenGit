using UnityEngine;

public class EnemyDamage : MonoBehaviour,IDamage
{
    [SerializeField]EnemyBase eBase;

    void Start()
    {
        if (GetComponent<EnemyBase>() != null)
            eBase = GetComponent<EnemyBase>();
    }

    public void Damage(int damage)
    {

        if (eBase.isDead) return;

        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        ////揺らす長さ
        //const float shakeLength = 0.3f;
        ////揺らす力
        //const float power = 0.3f;

        //StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion
        //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        eBase.Hp -= damage;        //HP減少処理

        eBase.isDamage = true;

        if (eBase.Hp <= 0)
            eBase.isDead = true;
    }

    public void Damage(int damage, bool deadSound)
    {
        Damage(damage);
        eBase.GetComponent<CreateDeadSound>().IsSoundEnable = deadSound;
    }
}

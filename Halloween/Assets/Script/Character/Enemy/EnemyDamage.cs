using UnityEngine;

public class EnemyDamage : MonoBehaviour,IDamage
{
    [SerializeField] EnemyBase eBase;
    [SerializeField] int Hp = 1;

    public bool IsDamage { get; set; } = false;
    void Start()
    {
        if (GetComponent<EnemyBase>() != null)
            eBase = GetComponent<EnemyBase>();
    }

    public bool Damage(int damage)
    {
        if (eBase.isDead) return false;
        if (IsDamage) return false;
        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        ////揺らす長さ
        //const float shakeLength = 0.3f;
        ////揺らす力
        //const float power = 0.3f;

        //StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion
        //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        Hp -= damage;        //HP減少処理

        IsDamage = true;

        if (Hp <= 0)
            eBase.isDead = true;

        return true;
    }

    public void Damage(int damage, bool deadSound)
    {
        Damage(damage);
        GetComponent<CreateDeadSound>().IsSoundEnable = deadSound;
    }
}

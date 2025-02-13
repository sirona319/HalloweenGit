using UnityEngine;

//ダメージ関数を持つスクリプト
public interface IDamage
{
    public void Damage(int damage);

    public virtual void Damage(int damage,bool sound) { }
}

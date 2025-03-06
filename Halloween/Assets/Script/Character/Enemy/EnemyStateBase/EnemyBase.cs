using UnityEngine;
using System;
//using static EnemyData;
using System.Collections.Generic;


public class EnemyBase : MonoBehaviour, IDamage
{
    #region ステートコントローラー
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    [NonSerialized] public bool IsDead = false;
    [NonSerialized] public bool IsDamage = false;
    [NonSerialized] public bool IsAttack = true;
    [NonSerialized] public bool IsMove = true;

    [SerializeField] EnemyDamage eDamage;

    public List<BaseMove> baseMove = new ();

    public int Hp = 0;

    protected virtual void StartInit()
    {
        if(GetComponent<EnemyDamage>()!=null)
            eDamage = GetComponent<EnemyDamage>();

        if (eDamage == null)
            Debug.Log("ダメージクラスが設定されていない");

    }

    public void Damage(int damage)
    {
        eDamage.Damage(damage);
    }

    public void Damage(int damage,bool isSound)
    {
        eDamage.Damage(damage, isSound);
    }

    public bool ReturnStateTypeDead()
    {
        if (IsDead) return true;

        return false;
    }

    public int ReturnStateMoveType(int stateType)
    {
        if (IsAttack)
            return (int)FlyCtr.State.Fly_Attack;

        else if (IsMove)
            return (int)FlyCtr.State.Fly_Move;


        return stateType;
    }
    
}

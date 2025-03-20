using UnityEngine;
using System;
//using static EnemyData;
using System.Collections.Generic;


public class EnemyBase : MonoBehaviour
{
    #region ステートコントローラー
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    [NonSerialized] public bool isDead = false;
    [NonSerialized] public bool isDamage = false;
    [NonSerialized] public bool isAttack = true;
    [NonSerialized] public bool isMove = true;

    [SerializeField] EnemyDamage eDamage;

    public List<BaseMove> baseMove = new ();

    //public int Hp = 0;

    //protected virtual void StartInit()
    //{
    //    //if(GetComponent<EnemyDamage>()!=null)
    //    //    eDamage = GetComponent<EnemyDamage>();

    //    //if (eDamage == null)
    //    //    Debug.Log("ダメージクラスが設定されていない");

    //}

    //public void Damage(int damage)
    //{
    //    eDamage.Damage(damage);
    //}

    //public void Damage(int damage,bool isSound)
    //{
    //    eDamage.Damage(damage, isSound);
    //}

    public bool ReturnStateTypeDead()
    {
        if (isDead) return true;

        return false;
    }

    public int ReturnStateMoveType(int stateType)
    {
        if (isAttack)
            return (int)FlyCtr.State.Fly_Attack;

        else if (isMove)
            return (int)FlyCtr.State.Fly_Move;


        return stateType;
    }
    
}

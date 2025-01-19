using UnityEngine;
using System;
using static EnemyData;
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

    //protected int hpPoint;

    [NonSerialized] public bool IsDead = false;
    [NonSerialized] public bool IsDamage = false;
    [NonSerialized] public bool IsAttack = true;
    [NonSerialized] public bool IsMove = true;



    [SerializeField]public EnemyData enemyData;//スクリプタルオブジェクト　リスト
    public string findName;


    //[NonSerialized] public List<BaseMagazine> baseMagazine=new ();
    public List<BaseMove> baseMove = new ();


    //public Transform[] movePointsDatas;

    //public int MaxHp = 1;
    [NonSerialized] public int Hp = 0;
    //public float MaxAtkInterval = 1f;
    [NonSerialized]public float AtkInterval =1;

    //const int ATKVAL = 1;

    //呼び出し先でキャストして使用する
    public BaseMove MoveTypeSelect(MoveType mt)
    {
        foreach (var move in baseMove)
        {

            if (move.GetType().FullName == mt.ToString())
                return move;
        }


        return null;
    }

    //public void AttackMagazineUpdate(AttackType atkType)
    //{

    //    foreach (var magazine in baseMagazine)
    //        if (magazine.GetType().FullName == atkType.ToString())
    //            magazine.MagazineUpdate();
        
    //}
    //public void AttackMagazineUpdateAll()
    //{
    //    foreach (var magazine in baseMagazine)
    //        magazine.MagazineUpdate();
    //}


    protected virtual void StartInit()
    {
        //スクリプタルオブジェクトのデータを取得
        enemyData = EnemyManager.I.GetEnemyData(findName);

        //enemyDataのnullチェック
        if (enemyData == null)
            throw new System.Exception(gameObject.name + "　Data null");



        // if((int)enemyData.attackType.Length<=0)
        //    throw new System.Exception(gameObject.name + "　スクリプタルオブジェクトattackType　空");

        //if ((int)enemyData.moveType.Length <= 0)
        //    throw new System.Exception(gameObject.name + "スクリプタルオブジェクト　moveType 空");
    }
    protected virtual void Init()
    {
        //ステータスの初期化
        Hp = enemyData.HpMax;


        //baseMagazine初期化
        //for (int i = 0; i < (int)enemyData.attackType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

        //    if (typeClass != null)
        //        baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

        //}

        //foreach (var magazine in baseMagazine)
        //    magazine.Initialize();


        //baseMove初期化
        //for (int i = 0; i < (int)enemyData.moveType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(enemyData.moveType[i].ToString());

        //    if (typeClass != null)
        //        baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));

        //}

        //foreach (var move in baseMove)
        //    move.Initialize();




        //enemyData.movePointsSet = movePointsInit;

    }

    #region アニメーションイベント

    //public void OnEnemyAttack()
    //{

    //    Debug.Log("OnEnemyAttack");
    //    //攻撃コリジョンを有効にする
    //    //HitCol.enabled = true;

    //}

    //public void OffEnemyAttack()
    //{
    //    Debug.Log("OffEnemyAttack");

    //    //HitCol.enabled = false;

    //}
    #endregion

    public virtual void EnemyDamage(int damage)
    {

        if (IsDead) return;


        Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        Hp -= damage;        //HP減少処理

        IsDamage = true;

        if (Hp <= 0)
            IsDead = true;
    }



    public int ReturnStateTypeDamage()
    {
        const int DAMAGESTATE = 1;
        return DAMAGESTATE;
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

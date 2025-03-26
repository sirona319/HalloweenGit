using System;
using UnityEngine;

public class PlayerAttackPointMove : BaseMove
{
    public PlayerAttackMove playerAttack;
    public PointMove point;

    const float atkTimeMax = 6f;

    bool IsAtkMode = false;
    float atkTime = atkTimeMax;

    [SerializeField] float len;

    [SerializeField] float attackLengeMax = 8;


    //Transform playerT;
    public override void Initialize()
    {
        base.Initialize();

        //point = gameObject.GetComponent<PointMove>();
        //playerAttack = gameObject.GetComponent<PlayerAttackMove>();

        playerAttack.Initialize();
        point.Initialize();

        atkTime = atkTimeMax;

        //playerT = GameObject.FindGameObjectWithTag(TagName.Player).transform;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {


        AttackMode();

        MoveMode();

        if (atkTime > 0)
            return;

        atkTime = atkTimeMax;
        if (playerAttack.targetTrans == null)
            return;

        Vector2 p = playerAttack.targetTrans.position;
        Vector2 t = transform.position;
        len = Vector2.Distance(p, t);
        //プレイヤーが離れていたら無し
        if (len < attackLengeMax)
        {
            //IsAtkMode = true;
            Debug.Log("攻撃" + gameObject.name);
        }
        else
        {
            IsAtkMode = false;
            Debug.Log("攻撃なし"+gameObject.name);

        }


        playerAttack.MoveEnter();


    }

    void AttackMode()
    {
        if (!IsAtkMode) return;

        playerAttack.MoveUpdate();

        if (playerAttack.isAttackEnd)
        {
            Debug.Log("移動へ切り替え");
            IsAtkMode = false;

        }
    }

    void MoveMode()
    {
        if (IsAtkMode) return;

        atkTime -= Time.deltaTime;
        point.MoveUpdate();
    }
}

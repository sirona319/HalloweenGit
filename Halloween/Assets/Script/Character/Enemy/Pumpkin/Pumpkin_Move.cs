using UnityEngine;

public class Pumpkin_Move : StateChildBase
{
    //[SerializeField] float MOVEXY = 100;
    //[SerializeField] Vector3[] movePos;
    //[SerializeField] Vector3 targetPos;
    //[SerializeField] float moveSaveTime = 0;


    //const float ENDMOVELEN = 1f;

    //Rigidbody m_rb;


    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //foreach (var move in GetComponent<FlyScr>().baseMove)
        //    move.Initialize();


        //GetComponent<FlyScr>().baseMove.move
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in GetComponent<PumpkinScr>().baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
        {
            return (int)PumpkinCtr.State.Pumpkin_Damage;
        }
            //if (GetComponent<EnemyBase>().IsDamage)
            //    if (GetComponent<EnemyBase>().ReturnStateTypeDead())
            //        return (int)FlyCtr.State.Fly_Dead;


            //移動の更新
            foreach (var move in GetComponent<PumpkinScr>().baseMove)
        {
            move.MoveUpdate();
            //GetComponent<FlyScr>().IsMove = move.IsMove;
        }

        //マガジンの更新



        if (!GetComponent<PumpkinScr>().IsMove)
            GetComponent<PumpkinScr>().IsAttack = true;

        //GetComponent<FlyScr>().AttackMagazineUpdateAll();

        //return GetComponent<FlyScr>().FlyReturnStateType(StateType);


        return (int)StateType;

    }
}

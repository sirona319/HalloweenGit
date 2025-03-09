using UnityEngine;

public class Fly_Move : StateChildBase
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

        foreach (var move in GetComponent<FlyScr>().baseMove)
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


        if (GetComponent<EnemyBase>().isDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)FlyCtr.State.Fly_Dead;


        //移動の更新
        foreach (var move in GetComponent<FlyScr>().baseMove)
        {
            move.MoveUpdate();
            //GetComponent<FlyScr>().isMove = move.isMove;
        }

        //マガジンの更新



        if (!GetComponent<FlyScr>().isMove)
            GetComponent<FlyScr>().isAttack = true;

        //GetComponent<FlyScr>().AttackMagazineUpdateAll();

        //return GetComponent<FlyScr>().FlyReturnStateType(StateType);


        return (int)StateType;

    }
}

using UnityEngine;

public class Fly_Move : StateChildBase
{
    //[SerializeField] float MOVEXY = 100;
    //[SerializeField] Vector3[] movePos;
    //[SerializeField] Vector3 targetPos;
    //[SerializeField] float moveSaveTime = 0;


    //const float ENDMOVELEN = 1f;

    //Rigidbody m_rb;

    FlyScr fScr;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //foreach (var move in GetComponent<FlyScr>().baseMove)
        //    move.Initialize();
        fScr = GetComponent<FlyScr>();
        fScr.move.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //foreach (var move in GetComponent<EnemyBase>().move)
            fScr.move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;


        if (GetComponent<IDamage>().IsDamage)
            if (fScr.ReturnStateTypeDead())
                return (int)FlyCtr.State.Fly_Dead;


        //移動の更新
        //foreach (var move in GetComponent<FlyScr>().baseMove)
        //{
        fScr.move.MoveUpdate();
        //GetComponent<FlyScr>().isMove = move.isMove;
        /// }

        //マガジンの更新



        //if (!GetComponent<FlyScr>().isMove)
        //    GetComponent<FlyScr>().isAttack = true;

        //GetComponent<FlyScr>().AttackMagazineUpdateAll();

        //return GetComponent<FlyScr>().FlyReturnStateType(StateType);
        if (!fScr.isMove)
            return (int)fScr.ReturnStateType(StateType);
        

        return (int)StateType;

    }
}

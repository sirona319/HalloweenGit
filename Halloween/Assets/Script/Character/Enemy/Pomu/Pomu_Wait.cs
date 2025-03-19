using UnityEngine;


public class Pomu_Wait : StateChildBase
{
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

    }

    public override void OnEnter()
    {
        stateTime = 0f;
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 5f);



        if (GetComponent<EnemyBase>().isDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)PomuCtr.State.Pomu_Dead;

        stateTime += Time.deltaTime;


        return GetComponent<PomuScr>().ReturnStateType(StateType);

    }

}

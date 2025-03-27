using UnityEngine;
public class Pomu_Damage : StateChildBase
{
    const float DAMAGETIMEMAX = 0.4f;
    //float damageTime = 0f;

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
    }
    public override void OnEnter()
    {
       // damageTime = 0f;
        stateTime = 0f;
        //オブジェクトを揺らしオン
        StartCoroutine(MyLib.DoShake(0.25f, 0.1f, transform));

       // damageTime = DAMAGETIMEMAX;

    }

    public override void OnExit()
    {
        gameObject.GetComponent<IDamage>().IsDamage = false;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (gameObject.GetComponent<EnemyBase>().isDead)
        {
            const int DEAD = 2;
            return DEAD;
        }

        if (stateTime >= DAMAGETIMEMAX)
        {

            return GetComponent<PomuScr>().ReturnStateType(StateType);
        }

        return StateType;
    }

}

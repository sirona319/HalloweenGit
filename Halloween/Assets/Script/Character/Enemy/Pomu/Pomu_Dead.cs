using UnityEngine;

public class Pomu_Dead : StateChildBase
{
    const float DEADTIME = 0.1f;

    //private ParticleSystem deadParticle;//パーティクル
    ParticleSystem deadParticleR;//パーティクル
    ParticleSystem deadParticleY;//パーティクル
    ParticleSystem deadParticleB;//パーティクル
    AudioSource deadSound;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        deadParticleR = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtR");
        deadParticleY = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtY");
        deadParticleB = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtB");

        deadSound = MyLib.GetComponentLoad<AudioSource>("prefab/Sound/DestroySound");


    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //GetComponent<CreateDeadSound>().Create();

        Instantiate(deadParticleR, transform.position, Quaternion.identity);
        Instantiate(deadParticleY, transform.position, Quaternion.identity);
        Instantiate(deadParticleB, transform.position, Quaternion.identity);

        var cols = GetComponents<BoxCollider2D>();

        foreach (var col in cols)
        {
            col.enabled = false;
        }
        //Destroy();
        //Destroy(GetComponent<DamagePlayer>());
        //GetComponent<DamagePlayer>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.SetActive(false);
        //Destroy(gameObject, 0);
        //GetComponent<EnemyBase>().isDead = true;
    }

    public override void OnExit()
    {
        //Destroy(gameObject, 0);

    }

    public override sealed int StateUpdate()
    {
        stateTime += Time.deltaTime;

        //if (stateTime >= DEADTIME)
        //{
        //    //return (int)PomuCtr.State.Pomu_Move;
        //}

            return (int)StateType;

    }

}

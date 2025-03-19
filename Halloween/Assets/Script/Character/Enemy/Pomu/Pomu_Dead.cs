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

        GetComponent<CreateDeadSound>().Create();

        Instantiate(deadParticleR, transform.position, Quaternion.identity);
        Instantiate(deadParticleY, transform.position, Quaternion.identity);
        Instantiate(deadParticleB, transform.position, Quaternion.identity);

        gameObject.SetActive(false);

    }

    public override void OnExit()
    {

    }

    public override sealed int StateUpdate()
    {
        stateTime += Time.deltaTime;

        return (int)StateType;

    }

}

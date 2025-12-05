using UnityEngine;

public class Fly_Dead : StateChildBase
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

        GetComponent<SpriteRenderer>().enabled = false;

        //StartCoroutine(MyLib.DelayCoroutine(DEADTIME, () =>
        //{
        //    //GameObject spawn = GameObject.Find("WaveSpawn");
        //    //spawn.GetComponent<EnemySpawnWave>().UpdateCount();

        //    if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
        //        GameSceneControl.I.UpdateEnemyCount();

        //    gameObject.SetActive(false);
        //    //Destroy(gameObject);

        //}));

        //クリアチェック　スコア加算　
        //if (SceneManager.GetActiveScene().name.Contains(GManager.SceneNameType.NormalScene.ToString()))
        //{
        //    //GameSceneControl.I.UpdateEnemyCount();
        //}

    }

    public override void OnExit()
    {

    }

    public override sealed int StateUpdate()
    {
        stateTime += Time.deltaTime;

        //if (stateTime > DEADTIME)
        //{
        //    Instantiate(deadParticle, transform.position, Quaternion.identity);

        //    gameObject.SetActive(false);
        //}


        return (int)StateType;

    }

    //public override void OnEnter()
    //{
    //    //var anim = gameObject.GetComponent<Animator>();
    //    //anim.SetBool("DamageB", false);
    //    //anim.SetTrigger("DeadT");

    //    base.OnEnter();
    //}
}

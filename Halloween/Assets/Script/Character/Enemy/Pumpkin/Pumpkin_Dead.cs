using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pumpkin_Dead : StateChildBase
{
    const float DEADTIME = 0.1f;

    //private ParticleSystem deadParticle;//パーティクル
    ParticleSystem deadParticleR;//パーティクル
    ParticleSystem deadParticleY;//パーティクル
    ParticleSystem deadParticleB;//パーティクル

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //deadParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/Flash_star_ellow_green");


        deadParticleR = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtR");
        deadParticleY = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtY");
        deadParticleB = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/BreakPtB");
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        GetComponent<CreateDeadSound>().Create();

        var pos= GetComponent<PumpkinScr>().baseMove[0].GetPos();

        Instantiate(deadParticleR, pos, Quaternion.identity);
        Instantiate(deadParticleY, pos, Quaternion.identity);
        Instantiate(deadParticleB, pos, Quaternion.identity);

        gameObject.SetActive(false);
        //Instantiate(deadParticle, transform.position, Quaternion.identity);

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

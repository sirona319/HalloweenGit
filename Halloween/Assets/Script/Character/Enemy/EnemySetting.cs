using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class EnemyData
{
    public string Id;//string　固定

    public enum MoveType
    {

        //RandomMove,
        //PointMove,
        //CircleMove,
        //PointCircleMove,
        //PlayerAttackMove,
        PlayerAttackPointMove,

        JumpMove,
        //randomApoint,

    }

    public enum AttackType
    {
        PlayerAttack
        //NormalMagazine,
        //FiveMagazine,
        //CircleMagazine,
        //NumAttackType,
    }

    public MoveType[] moveType;
    public AttackType[] attackType;

    //public MoveType moveType = MoveType.random;
    //public AttackType attackType = AttackType.normal;

    public float Speed;
    public int HpMax;
    //public int Hp;

    public float AtkIntervalMax = 1;

    //public GameObject go;
    //public float AtkInterval = 1;
    //public float AtkRandTimeMax;
    //public float AtkRandTimeMin;
    //public int Attack;

    //public bool FirstTargetPlayer=false;
    //public Transform[] movePointsSet;


}

[CreateAssetMenu(fileName = "EnemySetting", menuName = "Scriptable Objects/Enemy Setting")]
public class EnemySetting : ScriptableObject
{
    public List<EnemyData> DataList;
}

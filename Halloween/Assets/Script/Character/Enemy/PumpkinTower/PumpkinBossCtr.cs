﻿using System;

public class PumpkinBossCtr : StateControllerBase
{
    public enum State
    {
        PumpkinBoss_Wait,
        //PumpkinBoss_Damage,
        PumpkinBoss_Dead,
        PumpkinBoss_Attack,
        PumpkinBoss_AttackL2,
        PumpkinBoss_Fall,
        //PumpkinBoss_Move,
        //Pumpkin_Circle,


        NumStates
    }

    public override void Initialize(int initializeStateType)
    {

        for (int i = 0; i < (int)State.NumStates; i++) //NumStatesを使う場合
        {
            State type = (State)i;
            string className = type.ToString();
            Type typeClass = Type.GetType(className);

            if (typeClass != null)
            {
                var state = (StateChildBase)gameObject.AddComponent(typeClass);

                stateDic[i] = state;
                state.Initialize(i);

            }
        }


        CurrentState = initializeStateType;
        stateDic[CurrentState].OnEnter();
    }
}

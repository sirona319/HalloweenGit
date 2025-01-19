using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinCtr : StateControllerBase
{
    public enum State
    {
        Pumpkin_Wait,
        Pumpkin_Damage,
        Pumpkin_Dead,
        Pumpkin_Attack,
        Pumpkin_Move,
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

    //protected void BasePumpkinStateSet(State enemyState)
    //{
    //    AutoStateTransitionSequence((int)enemyState);
    //}
}

//public class BasePumpkin_Move : EnemyStateChildBaseMove2D{}

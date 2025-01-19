using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCtr : StateControllerBase
{
    public enum State
    {
        Fly_Wait,
        Fly_Damage,
        Fly_Dead,
        Fly_Attack,
        Fly_Move,
        //Fly_Circle,


        NumStates
    }

    public override void Initialize(int initializeStateType)
    {

        for (int i = 0; i < (int)State.NumStates; i++) //NumStates‚ðŽg‚¤ê‡
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

    //protected void BaseFlyStateSet(State enemyState)
    //{
    //    AutoStateTransitionSequence((int)enemyState);
    //}
}

//public class BaseFly_Move : EnemyStateChildBaseMove2D{}

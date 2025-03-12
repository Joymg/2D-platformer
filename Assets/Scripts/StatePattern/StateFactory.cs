using System;
using System.Collections.Generic;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Fall,
        Climb,
        Attack,
        Hit,
        Dead
    }

    public class StateFactory : MonoBehaviour
    {
        [SerializeField] private State Idle, Move, Jump, Fall, Climb, Attack, Hit, Dead;
        private Dictionary<StateType, State> stateDictionary;
        public State GetState(StateType stateType) => stateDictionary[stateType];

        private void Awake()
        {
            stateDictionary = new()
            {
                { StateType.Idle, Idle },
                { StateType.Move, Move },
                { StateType.Jump, Jump },
                { StateType.Fall, Fall },
                { StateType.Climb, Climb },
                { StateType.Attack, Attack },
                { StateType.Hit, Hit },
                { StateType.Dead, Dead },
            };
        }

        public void InitializeStates(Agent agent)
        {
            foreach (State state in stateDictionary.Values)
            {
                AgentState agentState = (AgentState)state;
                agentState.InitializeState(agent);
            }
        }
    }
}
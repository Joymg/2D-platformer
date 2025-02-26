using System;
using Joymg.Platformer2D.Input;
using Joymg.Platformer2D.States;
using UnityEngine;

namespace Joymg.Platformer2D.Entities
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] public Rigidbody2D body;
        [SerializeField] public PlayerInput agentInput;
        [SerializeField] public AgentAnimator animatorManager;
        [SerializeField] private AgentRenderer agentRenderer;

        [Header("States")] 
        public State initialState;
        public State currentState = null, previousState = null;

        private void Awake()
        {
            agentInput = GetComponentInParent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
            animatorManager = GetComponentInChildren<AgentAnimator>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();

            AgentState[] states = GetComponentsInChildren<AgentState>();
            foreach (AgentState state in states)
            {
                state.InitializeState(this);
            }
        }

        private void Start()
        {
            agentInput.OnMovement += agentRenderer.FaceDirection;
            SetState(initialState);
        }

        private void Update()
        {
            currentState.UpdateState();
        }


        private void HandleJump()
        {
            throw new NotImplementedException();
        }

        public void SetState(State newState)
        {
            if (!newState)
                return;
            if (currentState == newState)
                return;

            currentState?.ExitState();
            previousState = currentState;
            currentState = newState;
            currentState.EnterState();

            DisplayState();
        }

        private void DisplayState()
        {
            Debug.Log($"Agent: {gameObject.name} now in {currentState.GetType()}");
        }
    }
}
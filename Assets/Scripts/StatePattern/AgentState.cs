using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class AgentState : State
    {
        protected Agent _agent;
        [SerializeField]
        protected AgentState JumpState;

        public void InitializeState(Agent agent)
        {
            _agent = agent;
        }

        public override void EnterState()
        {
            _agent.agentInput.OnMovement += HandleMovement;
            _agent.agentInput.OnJumpPressed += HandleJumpPressed;
            _agent.agentInput.OnJumpReleased += HandleJumpReleased;
            _agent.agentInput.OnAttack += HandleAttack;
            OnEnter?.Invoke();
        }
        
        public override void UpdateState()
        {
        }
        
        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
            _agent.agentInput.OnMovement -= HandleMovement;
            _agent.agentInput.OnJumpPressed -= HandleJumpPressed;
            _agent.agentInput.OnJumpReleased -= HandleJumpReleased;
            _agent.agentInput.OnAttack -= HandleAttack;
            OnExit?.Invoke();
        }
        
        protected virtual void HandleMovement(Vector2 obj){ }

        protected virtual void HandleJumpPressed()
        {
            if (_agent.groundDetector.isGrounded)
            {
                _agent.SetState(JumpState);   
            }
        }

        protected virtual void HandleJumpReleased(){ }

        protected virtual void HandleAttack(){ }
    }
}
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class AgentState : State
    {
        protected Agent _agent;

        public void InitializeState(Agent agent)
        {
            _agent = agent;
            _agent.agentInput.OnMovement += HandleMovement;
            _agent.agentInput.OnJumpPressed += HandleJumpPressed;
            _agent.agentInput.OnJumpReleased += HandleJumpReleased;
            _agent.agentInput.OnAttack += HandleAttack;
            OnEnter?.Invoke();
            EnterState();
        }

        protected override void EnterState()
        {
        }
        
        public override void UpdateState()
        {
        }

        protected override void ExitState()
        {
            _agent.agentInput.OnMovement -= HandleMovement;
            _agent.agentInput.OnJumpPressed -= HandleJumpPressed;
            _agent.agentInput.OnJumpReleased -= HandleJumpReleased;
            _agent.agentInput.OnAttack -= HandleAttack;
            OnExit?.Invoke();
        }
        
        protected virtual void HandleMovement(Vector2 obj){ }
        
        protected virtual void HandleJumpPressed(){ }

        protected virtual void HandleJumpReleased(){ }

        protected virtual void HandleAttack(){ }
    }
}
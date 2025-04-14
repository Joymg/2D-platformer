using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public abstract class AgentState : State
    {
        protected Agent _agent;
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
            
            PerformEnter();
        }

        protected virtual void PerformEnter()
        {
            Debug.Log($"Agent: <color=green>{_agent.gameObject.name}</color> --> <color=red>{GetType().Name}</color>");
        }

        public override void UpdateState()
        {
            IsFalling();
        }

        protected bool IsFalling()
        {
            if (_agent.groundDetector.isGrounded) return false;
            
            _agent.SetState(_agent.StateFactory.GetState(StateType.Fall));
            return true;

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
                Debug.Log($"Jumping enabled : {_agent.groundDetector.isGrounded}");
                _agent.SetState(_agent.StateFactory.GetState(StateType.Jump));   
            }
        }

        protected virtual void HandleJumpReleased(){ }

        protected virtual void HandleAttack()
        {
            if (_agent.weaponManager.CanWeaponBeUsed(_agent.groundDetector.isGrounded))
            {
                _agent.SetState(_agent.StateFactory.GetState(StateType.Attack));
            }
        }

        public virtual void GetHit()
        {
            _agent.SetState(_agent.StateFactory.GetState(StateType.Hit));
        }

        public virtual void Die()
        {
            _agent.SetState(_agent.StateFactory.GetState(StateType.Dead));
        }
        
        
    }
}
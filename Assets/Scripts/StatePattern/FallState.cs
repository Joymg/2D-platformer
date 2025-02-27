using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class FallState : MovementState
    {
        [SerializeField] private float gravityModifier = 0.5f;

        public override void EnterState()
        {
            base.EnterState();
            _agent.animatorManager.PlayAnimation(AnimationType.Fall);
        }
        
        public override void UpdateState()
        {
            ControlFallHeight();
            CalculateVelocity();
            SetPlayerVelocity();
            
            if (_agent.groundDetector.isGrounded)
                _agent.SetState(IdleState);
        }
        
        protected override void HandleJumpPressed()
        {
            if(!_agent.groundDetector.isGrounded)
                return;
            
            base.HandleJumpPressed();
        }
        
        private void ControlFallHeight()
        {
            movementData.currentVelocity = _agent.body.velocity;
            movementData.currentVelocity.y += Physics2D.gravity.y * gravityModifier * Time.deltaTime;
            _agent.body.velocity = movementData.currentVelocity;
        }
    }
}
using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class JumpState: MovementState
    {

        private bool jumpPressed = false;

        protected override void PerformEnter()
        {
            _agent.animatorManager.PlayAnimation(AnimationType.Jump);
            movementData.currentVelocity = _agent.body.velocity;
            movementData.currentVelocity.y = _agent.data.jumpForce;
            _agent.body.velocity = movementData.currentVelocity;
            jumpPressed = true;
        }

        public override void UpdateState()
        {
            ControlJumpHeight();
            CalculateVelocity();
            SetPlayerVelocity();

            if (_agent.body.velocity.y <= 0f)
                _agent.SetState(FallState);
        }

        private void ControlJumpHeight()
        {
            if (jumpPressed) return;
            
            movementData.currentVelocity = _agent.body.velocity;
            movementData.currentVelocity.y += Physics2D.gravity.y * _agent.data.cutJumpGravityMultiplier * Time.deltaTime;
            _agent.body.velocity = movementData.currentVelocity;
        }

        protected override void HandleJumpPressed()
        {
            jumpPressed = true;
        }

        protected override void HandleJumpReleased()
        {
            jumpPressed = false;
        }
    }
}
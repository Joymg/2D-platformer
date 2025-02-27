using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class JumpState: MovementState
    {

        [SerializeField] private State FallState;
        [SerializeField] 
        private float jumpForce = 12f;

        [SerializeField]private float lowJumpGravityMultiplier = 2f;
        private bool jumpPressed = false;

        public override void EnterState()
        {
            _agent.animatorManager.PlayAnimation(AnimationType.Jump);
            movementData.currentVelocity = _agent.body.velocity;
            movementData.currentVelocity.y = jumpForce;
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
            if (!jumpPressed)
            {
                movementData.currentVelocity = _agent.body.velocity;
                movementData.currentVelocity.y += Physics2D.gravity.y * lowJumpGravityMultiplier;
                _agent.body.velocity = movementData.currentVelocity;
            }
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
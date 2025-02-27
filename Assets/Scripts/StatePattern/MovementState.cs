using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class MovementState : AgentState
    {
        [SerializeField] protected MovementData movementData;
        public State IdleState;

        public float acceleration, deceleration, maxSpeed;

        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
        }

        public override void EnterState()
        {
            _agent.animatorManager.PlayAnimation(AnimationType.Run);
            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0f;
            movementData.currentVelocity = Vector2.zero;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CalculateVelocity();
            SetPlayerVelocity();
            
            if (Mathf.Abs(_agent.body.velocity.x) < 0.01f)
            {
                _agent.animatorManager.PlayAnimation(AnimationType.Run);
            }
        }
        
        private void CalculateVelocity()
        {
            CalculateSpeed(_agent.agentInput.MovementVector);
            CalulateHorizontalDirection();
            movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
            movementData.currentVelocity.y = _agent.body.velocity.y;
            
        }

        private void CalulateHorizontalDirection()
        {
            if (_agent.agentInput.MovementVector.x > 0f)
            {
                movementData.horizontalMovementDirection = 1;
            }
            else if (_agent.agentInput.MovementVector.x < 0f)
            {
                movementData.horizontalMovementDirection = -1;
            }
        }

        private void CalculateSpeed(Vector2 movementVector)
        {
            if (Mathf.Abs(movementVector.x) > 0f)
            {
                movementData.currentSpeed += acceleration * Time.deltaTime;
            }
            else
            {
                movementData.currentSpeed -= deceleration * Time.deltaTime;
            }

            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, maxSpeed);
        }

        protected void SetPlayerVelocity()
        {
            _agent.body.velocity = movementData.currentVelocity;
        }

        
    }
}
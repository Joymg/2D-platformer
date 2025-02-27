using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class MovementState : AgentState
    {
        [SerializeField] protected MovementData movementData;
        public State IdleState;

        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
        }

        protected override void PerformEnter()
        {
            _agent.animatorManager.PlayAnimation(AnimationType.Run);
            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0f;
            movementData.currentVelocity = Vector2.zero;
        }

        public override void UpdateState()
        {
            if (IsFalling())
                return;
            
            CalculateVelocity();
            SetPlayerVelocity();
            
            if (Mathf.Abs(_agent.body.velocity.x) < 0.01f)
            {
                _agent.SetState(IdleState);
            }
        }
        
        protected void CalculateVelocity()
        {
            CalculateSpeed(_agent.agentInput.MovementVector);
            CalculateHorizontalDirection();
            movementData.currentVelocity = Vector3.right * (movementData.horizontalMovementDirection * movementData.currentSpeed);
            movementData.currentVelocity.y = _agent.body.velocity.y;
            
        }

        protected void CalculateHorizontalDirection()
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

        protected void CalculateSpeed(Vector2 movementVector)
        {
            if (Mathf.Abs(movementVector.x) > 0f)
            {
                movementData.currentSpeed += _agent.data.acceleration * Time.deltaTime;
            }
            else
            {
                movementData.currentSpeed -= _agent.data.deceleration * Time.deltaTime;
            }

            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, _agent.data.maxSpeed);
        }

        protected void SetPlayerVelocity()
        {
            _agent.body.velocity = movementData.currentVelocity;
        }

        
    }
}
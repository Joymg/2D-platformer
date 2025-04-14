﻿using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class IdleState: AgentState
    {
        protected override void PerformEnter()
        {
            base.PerformEnter();
            _agent.animatorManager.PlayAnimation(AnimationType.Idle);
            if (_agent.groundDetector.isGrounded || Mathf.Abs(_agent.agentInput.MovementVector.x) <= 0f)
            {
                _agent.body.velocity = Vector2.zero;
            }
        }

        public override void UpdateState()
        {
            if (IsFalling())
                return;
            
            if (_agent.climbingDetector && _agent.climbingDetector.CanClimb && Mathf.Abs(_agent.agentInput.MovementVector.y) > 0)
            {
                _agent.SetState(_agent.StateFactory.GetState(StateType.Climb));
            }
            else if (Mathf.Abs(_agent.agentInput.MovementVector.x) > 0)
            {
                _agent.SetState(_agent.StateFactory.GetState(StateType.Move));
            }
        }
    }
}
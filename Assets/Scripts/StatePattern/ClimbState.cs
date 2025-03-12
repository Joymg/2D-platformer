using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class ClimbState : AgentState
    {
        private float previousGravityScale = 0f;

        protected override void PerformEnter()
        {
            base.PerformEnter();
            _agent.animatorManager.PlayAnimation(AnimationType.Climb);
            _agent.animatorManager.StopAnimation();
            previousGravityScale = _agent.body.gravityScale;
            _agent.body.gravityScale = 0;
            _agent.body.velocity = Vector2.zero;
        }

        protected override void HandleJumpPressed()
        {
            _agent.SetState(_agent.StateFactory.GetState(StateType.Jump));
        }
        protected override void HandleAttack()
        {
            //prevent attack
        }

        public override void UpdateState()
        {
            if (_agent.agentInput.MovementVector.magnitude > 0)
            {
                _agent.animatorManager.StartAnimation();
                _agent.body.velocity = new(_agent.agentInput.MovementVector.x * _agent.data.climbSpeed.x,
                    _agent.agentInput.MovementVector.y * _agent.data.climbSpeed.y);
            }
            else
            {
                _agent.animatorManager.StopAnimation();
                _agent.body.velocity = Vector2.zero;
            }

            if (!_agent.climbingDetector.CanClimb)
                _agent.SetState(_agent.StateFactory.GetState(StateType.Idle));
        }

        public override void ExitState()
        {
            _agent.animatorManager.StartAnimation();
            _agent.body.gravityScale = previousGravityScale;
        }
    }
}
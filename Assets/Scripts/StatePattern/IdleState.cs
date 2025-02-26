using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class IdleState: AgentState
    {
        public State MoveState;
        public override void EnterState()
        {
            _agent.animatorManager.PlayAnimation(AnimationType.Idle);
        }

        protected override void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0)
            {
                _agent.SetState(MoveState);
            }
        }
    }
}
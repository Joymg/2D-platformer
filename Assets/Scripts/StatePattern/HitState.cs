using Joymg.Platformer2D.Entities;

namespace Joymg.Platformer2D.States
{
    public class HitState : AgentState
    {
        protected override void PerformEnter()
        {
            base.PerformEnter();
            _agent.animatorManager.PlayAnimation(AnimationType.Hit);
            _agent.animatorManager.OnAnimationEnd.AddListener(Recover);
        }

        protected override void HandleAttack()
        {
            //prevent attack
        }

        protected override void HandleJumpPressed()
        {
            //prevent jump
        }

        public override void GetHit()
        {
            //prevent getting hit
        }

        public override void UpdateState()
        {
        }

        public override void FixedUpdateState()
        {
        }

        private void Recover()
        {
            _agent.animatorManager.OnAnimationEnd.RemoveListener(Recover);
            _agent.SetState(_agent.StateFactory.GetState(StateType.Idle));
        }

        public override void ExitState()
        {
            base.ExitState();
            _agent.animatorManager.ResetEvents();
        }
    }
}
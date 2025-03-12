using System.Collections;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.States
{
    public class DeadState : AgentState
    {
        [SerializeField] private float timeToWaitBeforeRespawn = 1f;

        protected override void PerformEnter()
        {
            base.PerformEnter();
            _agent.animatorManager.PlayAnimation(AnimationType.Dead);
            _agent.animatorManager.OnAnimationEnd.AddListener(WaitBeforeDie);
            _agent.body.isKinematic = true;
            _agent.agentInput.enabled = false;
        }

        protected override void HandleJumpPressed()
        {
            //prevent jump
        }

        protected override void HandleAttack()
        {
            //prevent attack
        }

        public override void UpdateState()
        {
            _agent.body.velocity = new Vector2(0, _agent.body.velocity.y);
        }

        public override void FixedUpdateState()
        {
            //
        }

        public override void Die()
        {
            //prevent dead again while dying
        }

        private void WaitBeforeDie()
        {
            _agent.animatorManager.OnAnimationEnd.RemoveListener(WaitBeforeDie);
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(timeToWaitBeforeRespawn);
            _agent.OnDead?.Invoke();
        }

        public override void ExitState()
        {
            base.ExitState();
            StopAllCoroutines();
            _agent.animatorManager.ResetEvents();
            _agent.body.isKinematic = false;
            _agent.agentInput.enabled = true                  ;
        }
    }
}
using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.States
{
    public class AttackState : AgentState
    {
        [Header("Attack State")]
        [SerializeField]
        public LayerMask hittableLayerMask;

        protected Vector2 direction;

        public UnityEvent<AudioClip> OnWeaponPlay;
        [SerializeField] private bool showGizmos;

        protected override void PerformEnter()
        {
            base.PerformEnter();
            _agent.animatorManager.ResetEvents();
            _agent.animatorManager.PlayAnimation(AnimationType.Attack);
            _agent.animatorManager.OnAnimationEnd.AddListener(HandleTransition);
            _agent.animatorManager.OnAnimationAction.AddListener(PerformAttack);

            _agent.weaponManager.SetWeaponVisibility(true);
            direction = _agent.transform.right * (_agent.transform.localScale.x > 0 ? 1 : -1);
            if (_agent.groundDetector.isGrounded)
                _agent.body.velocity = Vector2.zero;
        }

        private void HandleTransition()
        {
            _agent.animatorManager.OnAnimationAction.RemoveListener(PerformAttack);
            _agent.SetState(_agent.groundDetector.isGrounded ? _agent.StateFactory.GetState(StateType.Idle) : _agent.StateFactory.GetState(StateType.Fall));
        }

        public override void UpdateState()
        {
            _agent.weaponManager.GetCurrentWeapon().PerformAttack(_agent, hittableLayerMask, direction);
        }

        public override void FixedUpdateState()
        {
        }

        protected override void HandleMovement(Vector2 obj)
        {
            //stop flipping rotation
        }

        protected override void HandleAttack()
        {
            //prevent attacking again
        }

        protected override void HandleJumpPressed()
        {
            //dont allow jumping
        }

        protected override void HandleJumpReleased()
        {
            //keep falling
        }

        private void PerformAttack()
        {
            OnWeaponPlay?.Invoke(_agent.weaponManager.GetCurrentWeapon().sfx);
            _agent.animatorManager.OnAnimationAction.RemoveListener(PerformAttack);
            
        }
        
        public override void ExitState()
        {
            //In case we got hit in the middle of the attack not to trigger a state transition
            _agent.animatorManager.ResetEvents();
            _agent.weaponManager.SetWeaponVisibility(false);
        }

        private void OnDrawGizmos()
        {
            if(!Application.isPlaying)
                return;
            
            if (!showGizmos)
                return;
            Gizmos.color = Color.red;
            Vector3 position = _agent.weaponManager.transform.position;
            _agent.weaponManager.GetCurrentWeapon().DrawWeaponGizmo(position, direction);
        }
    }
}
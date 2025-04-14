using System;
using System.Collections;
using UnityEngine;

namespace Joymg.Platformer2D.AI.Behaviours
{
    public class AIShootBehaviour : AIBehaviour
    {
        [SerializeField] private AIAgentDetector _agentDetector;
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private bool _isAttackOnCooldown;
        public override void PerformAction(AIEnemy enemyAI)
        {
            if (_isAttackOnCooldown)
                return;

            if (!_agentDetector.TargetDetected) 
                return;
            
            //Calls onMovement to make the enemy face the target
            enemyAI.InvokeOnMovement(_agentDetector.DirectionToTarget);
            enemyAI.InvokeOnAttack();
            _isAttackOnCooldown = true;
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_attackDelay);
            _isAttackOnCooldown = false;
        }
    }
}
using System;
using System.Collections;
using Joymg.Platformer2D.AI.Behaviour;
using UnityEngine;
using UnityEngine.Serialization;

namespace Joymg.Platformer2D.AI.Behaviours
{
    public class AIMeleeAttackBehaviour : AIBehaviour
    {
        public AIRangeDetector rangeDetector;
        [SerializeField] private bool isAttackOnCooldown;
        [SerializeField] private float attackDelay;

        private void Awake()
        {
            if (!rangeDetector)
                rangeDetector = GetComponentInChildren<AIRangeDetector>();
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isAttackOnCooldown)
                return;

            if (!rangeDetector.IsPlayerInRange)
                return;
            enemyAI.InvokeOnAttack();
            isAttackOnCooldown = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        private IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(attackDelay);
            isAttackOnCooldown = false;
        }
    }
}
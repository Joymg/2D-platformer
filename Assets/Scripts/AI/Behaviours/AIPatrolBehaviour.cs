using System;
using Joymg.Platformer2D.Detectors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Joymg.Platformer2D.AI.Behaviours
{
    public class AIPatrolBehaviour : AIBehaviour
    {
        public AIBlockedPathDetector changeDirectionDetector;
        private Vector2 movementVector = Vector2.zero;


        private void Awake()
        {
            if (!changeDirectionDetector)
                changeDirectionDetector = GetComponentInChildren<AIBlockedPathDetector>();
        }

        private void Start()
        {
            changeDirectionDetector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(Random.value > 0.5f ? 1 : -1, 0);
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0);
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.InvokeOnMovement(movementVector);
        }
    }
}
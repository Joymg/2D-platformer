using System;
using Joymg.Platformer2D.AI.Behaviour;
using Joymg.Platformer2D.Detectors;

namespace Joymg.Platformer2D.AI
{
    public class AIPatrollingEnemyBrain : AIEnemy
    {
        public GroundDetector agentGroundDetector;
        public AIBehaviour attackBehaviour, patrolBehaviour;

        private void Awake()
        {
            if (!agentGroundDetector)
                agentGroundDetector = GetComponentInChildren<GroundDetector>();
        }

        private void Update()
        {
            if (agentGroundDetector.isGrounded)
            {
                attackBehaviour.PerformAction(this);
                patrolBehaviour.PerformAction(this);
            }
        }
    }
}
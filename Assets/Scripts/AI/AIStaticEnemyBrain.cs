using System;
using Joymg.Platformer2D.AI;
using Joymg.Platformer2D.AI.Behaviours;
using Joymg.Platformer2D.Input;

namespace Joymg.Platformer2D.AI
{
    public class AIStaticEnemyBrain : AIEnemy
    {
        public AIBehaviour attackBehaviour;

        private void Update()
        {
            attackBehaviour.PerformAction(this);
        }
    }
}
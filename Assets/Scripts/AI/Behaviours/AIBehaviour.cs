using UnityEngine;

namespace Joymg.Platformer2D.AI.Behaviour
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract void PerformAction(AIEnemy enemyAI);
    }
}
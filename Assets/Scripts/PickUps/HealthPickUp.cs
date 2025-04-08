using UnityEngine;

namespace Joymg.Platformer2D.Entities.PickUps
{
    public class HealthPickUp : PickUp
    {
        [SerializeField] private int healthBoost = 1;
        public override void Collect(Agent agent)
        {
            Damageable damageable = agent.damageable;
            if (damageable == null)
                return;
            damageable.AddHealth(healthBoost);
        }
    }
}
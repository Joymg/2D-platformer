using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.WeaponSystem
{
    [CreateAssetMenu(fileName = "Melee Weapon Data", menuName = "Weapons/New Melee Weapon Data")]
    public class MeleeWeaponData : WeaponData
    {
        [SerializeField] protected float attackRange = 2;
        public override bool CanBeUsed(bool isGrounded)
        {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            Debug.Log($"Weapon {name} used");
            RaycastHit2D hit = Physics2D.Raycast(agent.weaponManager.transform.position, direction, attackRange,
                hittableMask);
            if (hit.collider)
            {
                IHittable[] hittables = hit.collider.GetComponents<IHittable>();
                foreach (IHittable hittable in hittables)
                {
                    hittable.GetHit(agent.gameObject, damage);
                }
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}
using Joymg.Platformer2D.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Joymg.Platformer2D.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Ranged Weapon Data", menuName = "Weapons/Ranged Weapon Data")]
    public class RangedWeaponData : WeaponData
    {
        public ThrowableWeapon rangedWeaponPrefab;
        public float initialSpeed;
        public float attackRange;

        public override bool CanBeUsed(bool isGrounded)
        {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            agent.weaponManager.SetWeaponVisibility(false);
            ThrowableWeapon throwable = Instantiate(rangedWeaponPrefab, agent.weaponManager.transform.position,
                quaternion.identity);
            throwable.spriteTransform.localScale = new Vector3(
                throwable.spriteTransform.localScale.x,
                agent.transform.localScale.x * throwable.spriteTransform.localScale.y,
                throwable.spriteTransform.localScale.z);
            throwable.Initialize(this, direction, hittableMask);
        }
    }
}
using System;
using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;

namespace Joymg.Platformer2D.Entities.PickUps
{
    public class ToolPickUp : PickUp
    {

        [SerializeField] private WeaponData weaponData;

        private void Start()
        {
            _spriteRenderer.sprite = weaponData.sprite;
        }

        public override void Collect(Agent agent)
        {
            agent.PickUp(weaponData);
        }
    }
}
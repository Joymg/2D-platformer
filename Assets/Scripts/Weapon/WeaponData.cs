using System;
using System.Collections;
using System.Collections.Generic;
using Joymg.Platformer2D.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Joymg.Platformer2D.WeaponSystem
{
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {
        public new string name;
        public Sprite sprite;
        public int damage = 1;
        public AudioClip sfx;

        public abstract bool CanBeUsed(bool isGrounded);

        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction) { }

        public bool Equals(WeaponData other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(sprite, other.sprite);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), sprite);
        }
    }
}
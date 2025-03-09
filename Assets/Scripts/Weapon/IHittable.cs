using UnityEngine;

namespace Joymg.Platformer2D.WeaponSystem
{
    public interface IHittable
    {
        void GetHit(GameObject agentGameObject, int damage);
    }
}
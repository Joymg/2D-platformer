using System;
using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;

namespace Joymg.Platformer2D.Feedback
{
    public class HittableKnockback: MonoBehaviour, IHittable
    {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float force = 10f;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        public void GetHit(GameObject agentGameObject, int damage)
        {
            Vector2 direction = transform.position - agentGameObject.transform.position;
            body.AddForce(new Vector2(direction.normalized.x,0)*force, ForceMode2D.Impulse);
        }
    }
}
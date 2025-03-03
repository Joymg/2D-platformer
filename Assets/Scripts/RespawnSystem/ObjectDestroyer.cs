using System;
using System.Collections;
using System.Collections.Generic;
using Joymg.Platformer2D.Entities;
using UnityEngine;

namespace Joymg.Platformer2D.RespawnSystem
{
    public class ObjectDestroyer : MonoBehaviour
    {
        public LayerMask objectToDestroyLayer;
        public Vector2 size;

        [Header("Gizmos parameters")] public Color gizmoColor = Color.red;
        public bool showGizmo = true;

        private void FixedUpdate()
        {
            Collider2D other = Physics2D.OverlapBox(transform.position, size, 0, objectToDestroyLayer);
            if (other)
            {
                if (!other.TryGetComponent(out Agent agent))
                {
                    Destroy(agent.gameObject);
                }

                agent.Die();
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawCube(transform.position, size);
            }
        }
    }
}
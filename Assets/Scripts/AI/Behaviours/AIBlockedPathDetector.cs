using System;
using System.Collections;
using UnityEngine;

namespace Joymg.Platformer2D.Detectors
{
    public class AIBlockedPathDetector : MonoBehaviour
    {
        public BoxCollider2D detectorCollider;

        //In case there is no more ground a block is detected, this layer mask is for that
        public LayerMask groundMask;
        public float groundRaycastLength = 2f;

        public bool PathBlocked { get; private set; }
        public event Action OnPathBlocked;

        [Header("Gizmo Parameters")] public Color colliderColor = Color.magenta;
        public Color groundRaycastColor = Color.blue;
        public bool showGizmos = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((groundMask & (1 << other.gameObject.layer)) != 0)
            {
                OnPathBlocked?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRaycastLength,
                groundMask);
            if (!hit.collider)
                OnPathBlocked?.Invoke();

            PathBlocked = hit.collider;
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = groundRaycastColor;
                Gizmos.DrawRay(detectorCollider.bounds.center, Vector3.down * groundRaycastLength);
                Gizmos.color = colliderColor;
                Gizmos.DrawCube(detectorCollider.bounds.center, detectorCollider.bounds.size);
            }
        }
    }
}
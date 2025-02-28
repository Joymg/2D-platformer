using System;
using UnityEngine;


namespace Joymg.Platformer2D.Detectors
{
    public class ClimbingDetector : MonoBehaviour
    {
        public LayerMask climbingLayermask;
        [SerializeField] private bool canClimb;

        public bool CanClimb
        {
            get => canClimb;
            private set => canClimb = value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;
            if ((collisionLayerMask & climbingLayermask) != 0)
                canClimb = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;
            if ((collisionLayerMask & climbingLayermask) != 0)
                canClimb = false;
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace Joymg.Platformer2D.AI.Behaviours
{
    public class AIAgentDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetMask;
        [field: SerializeField] public bool TargetDetected { get; private set; }
        private GameObject _target;
        [SerializeField] private Transform _detectorOrigin;
        [SerializeField] private Vector2 _detectorSize = Vector2.one;
        [SerializeField] private Vector2 _detectorOffset = Vector2.zero;
        [SerializeField] private float detectionDelay = 0.3f;
        public Vector2 DirectionToTarget => _target.transform.position - _detectorOrigin.position;

        [Header("Gizmo Params")] public bool showGizmos = true;
        public Color gizmoIdleColor = Color.green;
        public Color gizmoDetectionColor = Color.red;

        public GameObject Target
        {
            get => _target;
            private set
            {
                _target = value;
                TargetDetected = _target != null;
            }
        }


        private void Start()
        {
            StartCoroutine(DetectionCoroutine());
        }

        private IEnumerator DetectionCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(detectionDelay);
                Collider2D collider = Physics2D.OverlapBox((Vector2)_detectorOrigin.position + _detectorOffset,
                    _detectorSize,
                    0,
                    _targetMask);

                Target = collider ? collider.gameObject : null;
            }
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos || !_detectorOrigin)
                return;
            Gizmos.color = TargetDetected ? gizmoDetectionColor : gizmoIdleColor;
            Gizmos.DrawCube((Vector2)_detectorOrigin.position + _detectorOffset, _detectorSize);
        }
    }
}
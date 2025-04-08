using System;
using DG.Tweening;
using UnityEngine;

namespace Joymg.Platformer2D.Animations
{
    public class HoverEffect : MonoBehaviour
    {
        public float movementDistance = 0.5f;
        public float duration = 1f;
        public Ease animationEase;

        private void Start()
        {
            transform.DOMoveY(transform.position.y + movementDistance, duration).SetEase(animationEase)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            DOTween.Kill(transform);
        }
    }
}
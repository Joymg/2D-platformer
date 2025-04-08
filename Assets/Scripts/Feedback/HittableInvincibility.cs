using System.Collections;
using DG.Tweening.Core.Easing;
using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;

namespace Joymg.Platformer2D.Feedback
{
    public class HittableInvincibility : MonoBehaviour, IHittable
    {
        [SerializeField] private Collider2D[] _colliders;
        [SerializeField] private float duration = 0.8f;
        
        
        public SpriteRenderer spriteRenderer;
        public float flashDelay = 0.1f;
        [Range(0, 1)]
        public float flashAlpha = 0.5f;

        private void Awake()
        {
            _colliders = GetComponents<Collider2D>();
        }

        public void GetHit(GameObject agentGameObject, int damage)
        {
            if (enabled==false)
                return;
            
            ActivateColliders(false);
            StartCoroutine(RemoveInvincibility());
            StartCoroutine(SetTransparency(flashAlpha));
        }


        private void ActivateColliders(bool active)
        {
            foreach (Collider2D collider in _colliders)
            {
                collider.enabled = active;
            }
        }

        private IEnumerator RemoveInvincibility()
        {
            yield return new WaitForSeconds(duration);
            StopAllCoroutines();
            ActivateColliders(true);
            SetSpriteAlphaValue(1);
        }
        
        private IEnumerator SetTransparency(float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            SetSpriteAlphaValue(alpha);
            yield return new WaitForSeconds(flashDelay);
            //Remove Invincibility Coroutine stops this coroutine
            StartCoroutine(SetTransparency(alpha < 1 ? 1 : alpha));
        }
        
        
        private void SetSpriteAlphaValue(float alpha)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
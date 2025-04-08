using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Joymg.Platformer2D.Feedback
{
    public class FlashWhiteFeedback : MonoBehaviour
    {
        private static readonly int ApplySolidColorID = Shader.PropertyToID("_ApplySolidColor");
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float feedbackTime = 0.1f;

        public void PlayFeedback()
        {
            if (!_spriteRenderer || _spriteRenderer.material.HasProperty(ApplySolidColorID) == false)
                return;

            SetSolidColor(true);
            StopAllCoroutines();
            StartCoroutine(ResetColor());
        }

        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(feedbackTime);
            SetSolidColor(false);
        }

        private void SetSolidColor(bool solid)
        {
            _spriteRenderer.material.SetFloat(ApplySolidColorID, solid ? 1 : 0);
        }
    }
}
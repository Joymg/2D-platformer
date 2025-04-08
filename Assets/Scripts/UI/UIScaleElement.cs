using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Joymg.Platformer2D.UI
{
    public class UIScaleElement : MonoBehaviour
    {
        private Sequence sequence;
        [SerializeField] private RectTransform element;
        [SerializeField] private float targetScaleValue;
        [SerializeField] private float animationDuration;
        [SerializeField] private bool loop;

        private Vector3 baseScale, targetScale;

        private void Start()
        {
            baseScale = element.localScale;
            targetScale = Vector3.one * targetScaleValue;

            if (loop)
            {
                sequence = DOTween.Sequence()
                    .Append(element.DOScale(baseScale, animationDuration))
                    .Append(element.DOScale(targetScale, animationDuration));
                sequence.SetLoops(-1, LoopType.Yoyo);
                sequence.Play();
            }
        }


        public void PlayAnimation()
        {
            StopAllCoroutines();
            element.localScale = baseScale;
            StartCoroutine(ScaleElement(true));
        }

        private IEnumerator ScaleElement(bool scaleUp)
        {
            float time = 0;
            while (time < animationDuration)
            {
                time += Time.deltaTime;
                float elapsedRate = (time / animationDuration);
                element.localScale = scaleUp 
                        ? baseScale + elapsedRate * (targetScale - baseScale)
                        : targetScale - elapsedRate * (targetScale - baseScale);
                
                yield return null;
            }

            element.localScale = scaleUp ? targetScale : baseScale;
            //if looping restart coroutine
            if (loop || scaleUp)
                StartCoroutine(ScaleElement(!scaleUp));
        }

        private void OnDestroy()
        {
            sequence?.Kill();
        }
    }
}
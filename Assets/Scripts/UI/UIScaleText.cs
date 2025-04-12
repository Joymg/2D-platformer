using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Joymg.Platformer2D.UI
{
    public class UIScaleText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float animationSize = 80f;
        [SerializeField] private float duration = 0.3f;
        private float baseFontSize;

        private void Awake()
        {
            baseFontSize = text.fontSize;
        }

        public void PlayAnimation()
        {
            StopAllCoroutines();
            text.fontSize = baseFontSize;
            StartCoroutine(AnimateText());
        }

        private IEnumerator AnimateText()
        {
            float time = 0;
            float delta = animationSize - baseFontSize;
            while (time < duration)
            {
                time += Time.deltaTime;
                float fontSize = baseFontSize + delta * (time / duration);
                text.fontSize = fontSize;
                yield return null;
            }
            text.fontSize = baseFontSize;
        }
    }
}

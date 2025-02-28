using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.UI
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        public UnityEvent OnTextChange;

        private void Awake()
        {
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetScore(int newScore)
        {
            scoreText.SetText(newScore.ToString());
            OnTextChange?.Invoke();
        }
    }
}


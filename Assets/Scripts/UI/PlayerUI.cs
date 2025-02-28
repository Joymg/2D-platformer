using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joymg.Platformer2D.UI
{
    public class PlayerUI : MonoBehaviour
    {
        private HealthUI _healthUI;
        private ScoreUI _scoreUI;

        private void Awake()
        {
            _healthUI = GetComponentInChildren<HealthUI>();
            _scoreUI = GetComponentInChildren<ScoreUI>();
        }

        public void InitializeMaxHealth(int maxHealth)
        {
            _healthUI.Initialize(maxHealth);
        }

        public void SetHealth(int currentHealth)
        {
            _healthUI.SetHealth(currentHealth);
        }

        public void SetPoints(int currentPoints)
        {
            _scoreUI.SetScore(currentPoints);
        }
    }
}

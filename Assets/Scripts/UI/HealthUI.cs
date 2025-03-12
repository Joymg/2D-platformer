using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private List<HealthPointElementUI> _healthPoints;
    [SerializeField] private Sprite fullSprite, halfSprite, emptySprite;
    [SerializeField] private HealthPointElementUI healthElementPrefab;

    public void Initialize(int maxHealth)
    {
        _healthPoints = new();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth / 2; i++)
        {
            HealthPointElementUI life = Instantiate(healthElementPrefab, transform, false);
            _healthPoints.Add(life);
        }
    }

    public void SetHealth(int currentHealth)
    {
        for (int i = 0; i < _healthPoints.Count; i++)
        {
            if (i * 2 < currentHealth)
            {
                if (currentHealth - i * 2 == 1)
                    _healthPoints[i].SetSprite(halfSprite);

                else
                    _healthPoints[i].SetSprite(fullSprite);
            }
            else
            {
                _healthPoints[i].SetSprite(emptySprite);
            }
        }
    }
}
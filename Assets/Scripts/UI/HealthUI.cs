using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private List<HealthPointElementUI> _healthPoints;
    [SerializeField] private Sprite fullSprite, halfSprite, emptySprite;
    [SerializeField] private HealthPointElementUI healthElementPrefab;

    private void Start()
    {
        Initialize(10);
    }

    private void Initialize(int maxHealth)
    {
        _healthPoints = new();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth/2; i++)
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
                _healthPoints[i].SetSprite(currentHealth % 2 == 0 ? halfSprite : fullSprite);
            }
            else
            {
                _healthPoints[i].SetSprite(emptySprite);
            }
        }
    }
}

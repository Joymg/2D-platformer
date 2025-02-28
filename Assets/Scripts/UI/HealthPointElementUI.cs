using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthPointElementUI : MonoBehaviour
{
    private Image _image;
    public UnityEvent OnSpriteChange;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetSprite(Sprite newSprite)
    {
        if (_image.sprite != newSprite)
        {
            OnSpriteChange?.Invoke();
            _image.sprite = newSprite;
        }
    }
}

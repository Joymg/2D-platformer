using System;
using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Joymg.Platformer2D.UI
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _keytip;

        private void Awake()
        {
            _image ??= GetComponentInChildren<Image>();
        }

        private void Start()
        {
            _keytip.SetActive(false);
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}
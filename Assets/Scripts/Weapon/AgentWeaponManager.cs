using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.WeaponSystem
{
    public class AgentWeaponManager : MonoBehaviour
    {
        public SpriteRenderer weaponSprite;
        private WeaponStorage _storage;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapon;
        public UnityEvent OnWeaponPickUp;

        private void Awake()
        {
            _storage = new WeaponStorage();
            weaponSprite = GetComponent<SpriteRenderer>();
            SetWeaponVisibility(false);
        }

        public void SetWeaponVisibility(bool visible)
        {
            if (visible)
            {
                SwapWeaponSprite(GetCurrentWeapon().sprite);
            }

            weaponSprite.enabled = visible;
        }

        public WeaponData GetCurrentWeapon() => _storage.GetCurrentWeapon();

        private void SwapWeaponSprite(Sprite newWeaponSprite)
        {
            weaponSprite.sprite = newWeaponSprite;
            OnWeaponSwap?.Invoke(newWeaponSprite);
        }

        public void SwapWeapon()
        {
            if (_storage.WeaponCount <= 0)
                return;
            
            SwapWeaponSprite(_storage.SwapWeapon().sprite);
        }

        private void AddWeaponData(WeaponData weaponData)
        {
            if (!_storage.TryAddWeaponData(weaponData))
                return;
            if (_storage.WeaponCount == 2)
                OnMultipleWeapon?.Invoke();
            SwapWeaponSprite(weaponData.sprite);
        }

        public void PickUpWeapon(WeaponData weaponData)
        {
            AddWeaponData(weaponData);
            OnWeaponPickUp?.Invoke();
        }

        public bool CanWeaponBeUsed(bool isGrounded)
        {
            if (_storage.WeaponCount <= 0)
                return false;
            return _storage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetWeaponNames()
        {
            return _storage.GetWeaponNames();
        }
    }
}
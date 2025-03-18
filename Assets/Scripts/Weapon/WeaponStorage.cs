using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Joymg.Platformer2D.WeaponSystem
{
    [Serializable]
    public class WeaponStorage
    {
        private List<WeaponData> _weaponList = new();
        private int _currentWeaponIndex = -1;
        public int WeaponCount => _weaponList.Count;
        

        public WeaponData GetCurrentWeapon()
        {
            if (_currentWeaponIndex == -1)
                return null;
            return _weaponList[_currentWeaponIndex];
        }

        public WeaponData SwapWeapon()
        {
            if (_currentWeaponIndex == -1)
                return null;
            _currentWeaponIndex++;
            if (_currentWeaponIndex >= _weaponList.Count)
                _currentWeaponIndex = 0;
            return _weaponList[_currentWeaponIndex];
        }

        public bool TryAddWeaponData(WeaponData weaponData)
        {
            if (_weaponList.Contains(weaponData))
                return false;
            _weaponList.Add(weaponData);
            _currentWeaponIndex = WeaponCount - 1;
            return true;
        }

        public List<string> GetWeaponNames()
        {
            return _weaponList.Select(weapon => weapon.name).ToList();
        }
    }
}
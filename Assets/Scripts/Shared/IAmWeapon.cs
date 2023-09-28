using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Shared
{
    public interface IAmWeapon 
    {
        public WeaponScriptableObject WeaponData { get;}
        public int TotalAmmoAvailable { get;}
        public void Fire();
        public void Reload();
        public void DropIt();
        public bool isHit();
        public bool CanShoot();
        public void PickUp();
        public bool IsPlayerHoldingWeapon();

    }
}

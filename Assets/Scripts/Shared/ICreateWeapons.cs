using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Shared
{
    public interface ICreateWeapons 
    {
        public IAmWeapon CreateWeapon(WeaponType weapon, Vector3 offset,Transform parent=null);
        public IAmWeapon SpawnRandomWeapon(Vector3 offset,Transform parent=null);
    }
}
public enum WeaponType
{
    pistol, rocketLauncher, bow
}
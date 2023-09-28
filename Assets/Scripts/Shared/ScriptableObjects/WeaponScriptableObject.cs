using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Shared
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        public int MaxAmmosThatCanBeCarried;
        public int MagazineSize;
        public int Damage;
        public float FireRate;
        public float ReloadTime;
        public WeaponType WeaponType;

    }
}

using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MagicCraft.Weapons
{
    public class WeaponFactory : ICreateWeapons
    {
        public Dictionary<WeaponType, GameObject> Weapons;
        public List<WeaponType> WeaponTypes;
        System.Random random = new System.Random();
        [Inject]
        public void Constructor(Dictionary<WeaponType, GameObject> weapons)
        {
            Weapons = weapons;
            WeaponTypes =Weapons.Keys.ToList();

        }

        public IAmWeapon CreateWeapon(WeaponType weaponType, Vector3 positionOffset, Transform parent = null)
        {
            GameObject weapon =GameObject.Instantiate(Weapons[weaponType]);
            if(parent != null)
            {
                weapon.transform.parent = parent;
                weapon.transform.localPosition = positionOffset;
                weapon.transform.localRotation = Quaternion.identity;
                 
            }
            return weapon.GetComponent<IAmWeapon>();
        }

        public IAmWeapon SpawnRandomWeapon(Vector3 offset, Transform parent = null)
        {
           return CreateWeapon(WeaponTypes[random.Next(WeaponTypes.Count)],Vector3.zero, parent);
        }
    }
}


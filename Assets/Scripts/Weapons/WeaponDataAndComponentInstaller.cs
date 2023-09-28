using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace MagicCraft.Weapons
{
    public class WeaponDataAndComponentInstaller : MonoInstaller<WeaponDataAndComponentInstaller>
    {
        public List<GameObject> weapons;

        private Dictionary<WeaponType, GameObject> weaponsTypesAndWeaponDictionary;
        public override void InstallBindings()
        {
            weaponsTypesAndWeaponDictionary = new Dictionary<WeaponType, GameObject>();
            foreach (var weapon in weapons)
            {
                WeaponType weaponType = weapon.GetComponent<IAmWeapon>().WeaponData.WeaponType;
                weaponsTypesAndWeaponDictionary.Add(weaponType, weapon);
            }
            Container.Bind<Dictionary<WeaponType, GameObject>>().FromInstance(weaponsTypesAndWeaponDictionary).AsSingle();
            Container.Bind<ICreateWeapons>().To<WeaponFactory>().AsSingle();
        }
    }
}

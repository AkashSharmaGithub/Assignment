using MagicCraft.Shared;
using MagicCraft.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft
{
    public class Pistol : MonoBehaviour, IAmWeapon
    {
        [SerializeField] private Transform bulletShootingPoint;
        [SerializeField] private ParticleSystem gunshot;
        [field: SerializeField] public WeaponScriptableObject WeaponData { get; private set; }

        public int TotalAmmoAvailable { get; private set; }

        private Transform cameraTransform;
        private int ammoAvailableInMagazine;
        private float fireRateTimer;
        private float reloadTimer;

        private void Awake()
        {
            cameraTransform = Camera.main.transform;
        }
        private void OnEnable()
        {
            SetWeaponData();
        }
        private void SetWeaponData()
        {

            TotalAmmoAvailable = WeaponData.MaxAmmosThatCanBeCarried / 2;
            ammoAvailableInMagazine = WeaponData.MagazineSize;
            TotalAmmoAvailable -= ammoAvailableInMagazine;
            fireRateTimer = 0;
            reloadTimer = 0;
        }

        public bool CanShoot()
        {
            if (ammoAvailableInMagazine > 0 && CanFire() && IsReloading() == false && IsPlayerHoldingWeapon())
            {
                return true;
            }
            return false;
        }

        public void DropIt()
        {
            throw new System.NotImplementedException();
        }

        public void Fire()
        {
            if (CanShoot() == false)
            {
                return;
            }

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, float.MaxValue))
            {
                Debug.Log($"hit the gmaeobject called {hit.collider.gameObject.name} and did damage of {WeaponData.Damage} with remaining {TotalAmmoAvailable} left and ammo left in magazine is {ammoAvailableInMagazine}");

            }
            fireRateTimer = WeaponData.FireRate;
            ammoAvailableInMagazine--;
            if (ammoAvailableInMagazine <= 0&& TotalAmmoAvailable > 0)
            {
                reloadTimer = WeaponData.ReloadTime;
            }
            gunshot.Play();

        }
        public bool CanFire()
        {
            return (fireRateTimer <= 0);
        }
        public bool isHit()
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            if (ammoAvailableInMagazine == WeaponData.MagazineSize || IsReloading()||TotalAmmoAvailable==0)
            { return; }
            reloadTimer = WeaponData.ReloadTime;


        }
        public bool IsReloading()
        {
            return reloadTimer > 0;
        }
        private void Update()
        {
            CheckAndStartReload();
            if (fireRateTimer > 0)
            {
                fireRateTimer -= Time.deltaTime;
            }
        }
        public void CheckAndStartReload()
        {
            if (IsReloading())
            {
                Debug.Log($"Reloading:{reloadTimer}");
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0)
                {
                    if (TotalAmmoAvailable <= 0)
                    {
                        return;
                    }
                    Debug.Log($"Before adding  Ammo in gun:{ammoAvailableInMagazine} and total ammo :{TotalAmmoAvailable}");
                    if (TotalAmmoAvailable >= (WeaponData.MagazineSize - ammoAvailableInMagazine))
                    {
                        TotalAmmoAvailable -= (WeaponData.MagazineSize - ammoAvailableInMagazine);
                        ammoAvailableInMagazine = WeaponData.MagazineSize;
                    }
                    else
                    {
                        ammoAvailableInMagazine += TotalAmmoAvailable;
                        TotalAmmoAvailable = 0;
                    }
                    Debug.Log($"After adding  Ammo in gun:{ammoAvailableInMagazine} and total ammo :{TotalAmmoAvailable}");

                }
            }
        }
        public void PickUp()
        {

        }

        public bool IsPlayerHoldingWeapon()
        {
            return true;
        }
    }
}

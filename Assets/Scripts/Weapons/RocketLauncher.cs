using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Weapons
{
    public class RocketLauncher : MonoBehaviour,IAmWeapon
    {
        [SerializeField] private ParticleSystem rocketshootParticles;
        [field:SerializeField] public WeaponScriptableObject WeaponData { get; private set; }

        private Transform cameraTransform;

        public int TotalAmmoAvailable { get; private set; }

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
            if (ammoAvailableInMagazine > 0 && CanFire() && IsReloading() == false)
            {
                return true;
            }
            return false;
        }

        public void DropIt()
        {

        }

        public void Fire()
        {

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
                    if (TotalAmmoAvailable >= WeaponData.MagazineSize)
                    {
                        ammoAvailableInMagazine = WeaponData.MagazineSize;
                        TotalAmmoAvailable -= WeaponData.MagazineSize;
                    }
                    else
                    {
                        ammoAvailableInMagazine = TotalAmmoAvailable;
                        TotalAmmoAvailable = 0;
                    }

                }
            }

        }
        public bool IsReloading()
        {
            return reloadTimer > 0;
        }
        private void Update()
        {
            if (CanShoot() == false)
            {
                Reload();
                if (fireRateTimer > 0)
                {
                    fireRateTimer -= Time.deltaTime;
                }
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                fireRateTimer =WeaponData.FireRate;
                ammoAvailableInMagazine--;
                if (ammoAvailableInMagazine <= 0)
                {
                    reloadTimer = WeaponData.ReloadTime;
                }
                rocketshootParticles.Play();

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

using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Zenject;
namespace MagicCraft.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateManager : MonoBehaviour
    {
        [field:SerializeField]public Transform LookPosition { get; private set; }
        [field:SerializeField]public Transform WeaponPosition { get; private set; }
        public IProvideInput InputHandler { get; private set; }
        public PlayerStates PlayerStates { get; private set; }
        public PlayerActions PlayerActions { get; private set; }
        [field:SerializeField]public PlayerData PlayerData { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public Camera PlayerCamera { get; private set; }
        public PlayerMovementHandler PlayerMovementHandler { get; private set; }

        private ICreateWeapons weaponFactory;
        [field:SerializeField]public IAmWeapon CurrentWeapon { get;private set; }
        [Inject]
        public void InjectPlayerDataAndINputProvider(PlayerData data,IProvideInput input)
        {
            PlayerData = data;
            InputHandler = input;
            
        }
        [Inject]
        public void InjectWeaponFactory(ICreateWeapons weaponFactory)
        {
            this.weaponFactory = weaponFactory;
            CurrentWeapon = weaponFactory.SpawnRandomWeapon(Vector3.zero, WeaponPosition);
        }
  
        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            PlayerMovementHandler = new PlayerMovementHandler(this);
           // InputHandler = new PlayerInputHandler();
            InputHandler.EnableInput();
            PlayerCamera=Camera.main;
            PlayerStates = new PlayerStates(this);
            PlayerActions = new PlayerActions(this);
       
        }
        private void OnDisable()
        {
            InputHandler.DisableInput();
        }
        private void Update()
        {
            PlayerStates.Tick();
            PlayerActions.Tick();
        }
        // Start is called before the first frame update

    }
}

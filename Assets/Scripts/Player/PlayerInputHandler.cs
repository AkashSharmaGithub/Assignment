using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace MagicCraft.Player
{
    public class PlayerInputHandler : IProvideInput
    {
        private PlayerInput playerInputAction;
        Vector3 direction;
        private Vector2 movementVector;
        private Vector2 lookVector;
        private bool isMoving;
        public PlayerInputHandler()
        {
            EnableInput();
            isMoving = false;
            movementVector = Vector2.zero;
            lookVector= Vector2.zero;
            direction =Vector3.zero;
        }
        public Vector2 GetLookVector()
        {
            lookVector = playerInputAction.Input.Look.ReadValue<Vector2>();
            return lookVector;
        }
        public Vector2 GetMovementVector()
        {
            movementVector= playerInputAction.Input.Move.ReadValue<Vector2>();
            return playerInputAction.Input.Move.ReadValue<Vector2>();
        }
        public Vector3 GetDirection()
        {
            movementVector= playerInputAction.Input.Move.ReadValue<Vector2>();
            direction = new Vector3(movementVector.x, 0, movementVector.y).normalized;
            Debug.Log($"direction:{direction}");
            return direction;
        }
        public bool IsPlayerMoving()
        {
            GetMovementVector();
            isMoving = (movementVector.x != 0 || movementVector.y != 0);
            return isMoving;
        }

        public void EnableInput()
        {
            playerInputAction = new PlayerInput();
            playerInputAction.Enable();
        }

        public void DisableInput()
        {
            if(playerInputAction == null)
            {
                return;
            }
            playerInputAction.Disable();
        }

        public bool IsShootingButtonPressed()
        {
            
                return playerInputAction.Input.Fire.IsPressed();
        }

        public bool isAiming()
        {
            return playerInputAction.Input.Aim.IsPressed();
        }

        public bool IsReloadButtonPressed()
        {
            return playerInputAction.Input.Reload.IsPressed();
        }

        public bool IsJumpButtonPressed()
        {
            return playerInputAction.Input.Jump.IsPressed();
        }
    }
}

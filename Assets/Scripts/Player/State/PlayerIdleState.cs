using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class PlayerIdleState :IAmPlayerState
    {
        public void EnterIntoState(PlayerStateManager manager)
        {
            Debug.Log("IN idle State");
        }

        public void ExitFromState(PlayerStateManager manager, IAmPlayerState nextState)
        {
           manager.PlayerStates.SetState(nextState);
           
        }

        public void StayInState(PlayerStateManager manager)
        {
            
            if (manager.InputHandler.isAiming())
            {
                ExitFromState(manager, manager.PlayerStates.AimState);
            }
            if(manager.InputHandler.IsJumpButtonPressed())
            {
                ExitFromState(manager,manager.PlayerStates.JumpState);
            }
            if(manager.InputHandler.IsPlayerMoving())
            {
                ExitFromState(manager,manager.PlayerStates.MoveState);
                return;
            }
            manager.PlayerMovementHandler.RotatePlayer();
            manager.PlayerMovementHandler.AddGravity();
            manager.PlayerMovementHandler.ApplyMovement();
            
        }
        public void rotatePlayerInHorizontalAxis(PlayerStateManager manager)
        {
            Vector2 lookDirection = manager.InputHandler.GetLookVector();
            Vector3 rotation = manager.transform.rotation.eulerAngles;
            rotation.y += lookDirection.x * manager.PlayerData.HorizontalLookSentivity * Time.deltaTime;
            manager.transform.rotation =Quaternion.Euler(rotation);
            Vector3 positionOfLookPosition = manager.LookPosition.position;
            positionOfLookPosition.y+= lookDirection.y * manager.PlayerData.VerticalLookSentivity * Time.deltaTime;
            positionOfLookPosition.y = Mathf.Clamp(positionOfLookPosition.y, 0, 5f);
            manager.LookPosition.position=positionOfLookPosition;
        }

    }
}

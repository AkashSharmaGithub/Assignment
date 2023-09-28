using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class PlayerMoveState : IAmPlayerState
    {
        Vector3 direction;
        public void EnterIntoState(PlayerStateManager manager)
        {
            StayInState(manager);
        }
        public void ExitFromState(PlayerStateManager manager, IAmPlayerState nextState)
        {
            manager.PlayerStates.SetState(nextState);
        }

        public void StayInState(PlayerStateManager manager)
        {
            if (manager.InputHandler.IsJumpButtonPressed())
            {
                ExitFromState(manager, manager.PlayerStates.JumpState);
            }
            if (manager.InputHandler.isAiming())
            {
                ExitFromState(manager, manager.PlayerStates.AimState);
            }
            if (manager.InputHandler.IsPlayerMoving() == false)
            {
                ExitFromState(manager, manager.PlayerStates.IdleState);
            }
            manager.PlayerMovementHandler.MovePlayer();
            manager.PlayerMovementHandler.AddGravity();
            manager.PlayerMovementHandler.RotatePlayer();
            manager.PlayerMovementHandler.ApplyMovement();
        }

        

    }
}

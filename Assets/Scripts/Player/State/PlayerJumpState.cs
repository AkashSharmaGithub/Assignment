namespace MagicCraft.Player
{
    public class PlayerJumpState : IAmPlayerState
    {
        public void EnterIntoState(PlayerStateManager manager)
        {
            manager.PlayerMovementHandler.Jump();
            UnityEngine.Debug.Log("IN Jump State");
        }

        public void ExitFromState(PlayerStateManager manager, IAmPlayerState nextState)
        {
            manager.PlayerStates.SetState(nextState);
        }

        public void StayInState(PlayerStateManager manager)
        {
            manager.PlayerMovementHandler.MovePlayer();
            manager.PlayerMovementHandler.AddGravity();
            manager.PlayerMovementHandler.RotatePlayer();
            manager.PlayerMovementHandler.ApplyMovement();

            if (manager.CharacterController.isGrounded)
            {
                ExitFromState(manager, manager.PlayerStates.IdleState);
            }
           
        }
    }
}

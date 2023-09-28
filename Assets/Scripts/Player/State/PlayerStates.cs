using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MagicCraft.Player
{
    public class PlayerStates
    {
        public IAmPlayerState CurrentState { get; private set; }
        public IAmPlayerState IdleState { get; private set; }
        public IAmPlayerState MoveState { get; private set; }
        public IAmPlayerState AimState { get; private set; }
        public IAmPlayerState JumpState { get; private set; }
        public PlayerStateManager manager { get; private set; }
     
        public PlayerStates(PlayerStateManager manager)
        {
            this.manager=manager;
            IdleState=new PlayerIdleState();
            MoveState = new PlayerMoveState();
            AimState=new PlayerAimState();
            JumpState = new PlayerJumpState();
            SetState(IdleState);
        }
        public void SetState(IAmPlayerState state)
        {
            CurrentState = state;
            CurrentState.EnterIntoState(manager);
        }
        public void Tick()
        {
            CurrentState.StayInState(manager);
        }

       
    }
}

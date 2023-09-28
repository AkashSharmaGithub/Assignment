using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class ShootAction : IAmPlayerAction
    {
        public void ChangeAction(PlayerStateManager manager)
        {
            throw new System.NotImplementedException();
        }

        public void PerformAction(PlayerStateManager manager)
        {
            manager.CurrentWeapon.Fire();
          
            manager.PlayerActions.AddAction(manager.PlayerActions.IdleAction);
            manager.PlayerActions.RemoveAction(this);

            if (manager.InputHandler.IsReloadButtonPressed())
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.ReloadAction);
                manager.PlayerActions.RemoveAction(this);
            }
            if (manager.InputHandler.isAiming())
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.AimAction);
                manager.PlayerActions.RemoveAction(this);
            }
        }

        
    }
}

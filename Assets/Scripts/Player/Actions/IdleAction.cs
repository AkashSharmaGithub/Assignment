using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class IdleAction : IAmPlayerAction
    {
        public void ChangeAction(PlayerStateManager manager)
        {
        }

        public void PerformAction(PlayerStateManager manager)
        {
            if (manager.InputHandler.IsShootingButtonPressed() && manager.CurrentWeapon.CanShoot())
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.ShootAction);
                manager.PlayerActions.RemoveAction(this);
            }
            if (manager.InputHandler.IsReloadButtonPressed())
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.ReloadAction);
                manager.PlayerActions.RemoveAction(this);
            }
            if (manager.InputHandler.isAiming()==true)
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.AimAction);
                manager.PlayerActions.RemoveAction(this);
            }
        }

    }
}

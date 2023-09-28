using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class AimAction : IAmPlayerAction
    {
        public void ChangeAction(PlayerStateManager manager)
        {
            
        }

        public void PerformAction(PlayerStateManager manager)
        {
            if (manager.InputHandler.IsShootingButtonPressed() && manager.CurrentWeapon.CanShoot())
            {
                manager.PlayerActions.AddAction(manager.PlayerActions.ShootAction);
                manager.PlayerActions.RemoveAction(manager.PlayerActions.IdleAction);
            }
        }

       
    }
}

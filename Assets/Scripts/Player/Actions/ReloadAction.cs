using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class ReloadAction : IAmPlayerAction
    {
        public void ChangeAction(PlayerStateManager manager)
        {
        }

        public void PerformAction(PlayerStateManager manager)
        {
            manager.CurrentWeapon.Reload();
            manager.PlayerActions.AddAction(manager.PlayerActions.IdleAction);
            manager.PlayerActions.RemoveAction(this);
            
        }

       
    }
}

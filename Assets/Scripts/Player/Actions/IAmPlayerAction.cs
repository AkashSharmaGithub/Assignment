using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public interface IAmPlayerAction 
    {
        public void PerformAction(PlayerStateManager manager);
        public void ChangeAction(PlayerStateManager manager);
    }
}

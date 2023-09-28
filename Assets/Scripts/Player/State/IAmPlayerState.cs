using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public interface IAmPlayerState {
        public void EnterIntoState(PlayerStateManager manager);
        public void ExitFromState(PlayerStateManager manager, IAmPlayerState nextState);
        public void StayInState(PlayerStateManager manager);
    }
}

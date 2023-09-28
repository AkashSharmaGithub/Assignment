using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Shared
{
    public interface IProvideInput 
    {
        
        public Vector2 GetMovementVector();
        public Vector3 GetDirection();
        public bool IsPlayerMoving();
        public void EnableInput();
        public void DisableInput();
        public bool IsShootingButtonPressed();
        public bool IsJumpButtonPressed();
        public bool IsReloadButtonPressed();
        public bool isAiming();
        public Vector2 GetLookVector();

    }
}

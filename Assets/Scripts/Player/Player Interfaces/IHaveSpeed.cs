using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MagicCraft.Player
{
    public interface IHaveSpeed
    {
        public float Speed { get; }
        public void ChangeSpeed(float speedMultipler);
        public void ResetSpeed();
    }
}

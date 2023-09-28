using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public interface IHaveHealth 
    {
        public int Health { get; }
        public void ReduceHealth(int damage);
        public void AddHealth(int heathPointToAdd);
        public void ResetHealth();
    }
}

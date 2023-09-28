using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Shared
{
    public interface IamAmmo
    {
        public int Damage { get;}
        public float MoveSpeed { get; }
        public GameObject AmmoPrefab { get; }
        

    }
}

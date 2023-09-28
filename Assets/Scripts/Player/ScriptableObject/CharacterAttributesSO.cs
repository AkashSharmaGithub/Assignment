
using System;
using UnityEngine;

namespace MagicCraft.Player
{
    [CreateAssetMenu(menuName ="ScriptableObjects/Player/CharacterAttributes"),Serializable]
    public class CharacterAttributesSO : ScriptableObject
    {
        public int Health;
        public float Speed;
        public float JumpHeight;
        public float TimeToReachTheMaxHeight;
        public float HorizontalCameraSensitivity;
        public float VerticalCameraSensitivity;
        public float Gravity;
    }
}

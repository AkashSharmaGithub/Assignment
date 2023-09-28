using MagicCraft.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MagicCraft.Player
{
    [Serializable]
    public struct PlayerData : IHaveHealth, IHaveSpeed
    {
        [field:SerializeField]public int Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float HorizontalLookSentivity { get; private set; }
        [field: SerializeField] public float VerticalLookSentivity { get; private set; }
        [field: SerializeField] public float Gravity { get; private set; }
        [field: SerializeField] public float JumpSpeed { get; private set; }
        [field: SerializeField] public float TimeToReachTheMaxHeight { get; private set; }
        private CharacterAttributesSO characterAttributes;
     
        public  PlayerData(CharacterAttributesSO characterAttributesSO)
        {
            this.characterAttributes = characterAttributesSO;
            Health = characterAttributesSO.Health;
            Speed = characterAttributesSO.Speed;
            HorizontalLookSentivity = characterAttributes.HorizontalCameraSensitivity;
            VerticalLookSentivity = characterAttributes.VerticalCameraSensitivity;
            JumpSpeed = characterAttributes.JumpHeight;
            TimeToReachTheMaxHeight = characterAttributes.TimeToReachTheMaxHeight;
            Gravity = characterAttributesSO.Gravity;
        }
        public void ReduceHealth(int damage)
        {
            Health -= damage;
        }
        public void AddHealth(int heathPointToAdd)
        {
            Health += heathPointToAdd;
        }
        public void ResetHealth()
        {
            Health= characterAttributes.Health;
        }
        public void ChangeSpeed(float speedMultipler)
        {
            Speed *= speedMultipler;
        }
        public void ResetSpeed()
        {
            Speed=characterAttributes.Speed;
        }
  
    }
}

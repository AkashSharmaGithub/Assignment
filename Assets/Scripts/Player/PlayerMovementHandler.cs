using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace MagicCraft.Player
{
    public class PlayerMovementHandler
    {
        private Camera camera;
        private float maxLookYPosition = 5f;
        private float minLookYPosition = -2f;
        private float jumpDuration;         // Total jump duration
        private float jumpTimer;
        Vector2 lookDirection;
        PlayerStateManager manager;
        Vector3 moveDirection;
        Vector3 totalMovePosition;
        private bool isJumping = false;
        public PlayerMovementHandler(PlayerStateManager manager)
        {
            camera=Camera.main;
            this.manager=manager;
        }
        public void MovePlayer()
        {
            moveDirection = manager.InputHandler.GetDirection();
            moveDirection = camera.transform.forward * moveDirection.z + camera.transform.right * moveDirection.x;
            moveDirection.y = 0;
            totalMovePosition = moveDirection * manager.PlayerData.Speed * Time.deltaTime;
            manager.CharacterController.Move(totalMovePosition);
            //AddGravity();
        }

        public void AddGravity()
        {
            if (manager.CharacterController.isGrounded == false)
            {
                totalMovePosition.y -= manager.PlayerData.Gravity * Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
           
        }
        public void RotatePlayer()
        {
            lookDirection = manager.InputHandler.GetLookVector();
            Vector3 rotation = manager.transform.rotation.eulerAngles;
            rotation.y += lookDirection.x * manager.PlayerData.HorizontalLookSentivity * Time.deltaTime;
            manager.transform.rotation = Quaternion.Euler(rotation);
            RotateCamera();
        }

        private void RotateCamera() { 
            Vector3 positionOfLookPosition = manager.LookPosition.localPosition;
            positionOfLookPosition.y += lookDirection.y * manager.PlayerData.VerticalLookSentivity * Time.deltaTime;
            positionOfLookPosition.y = Mathf.Clamp(positionOfLookPosition.y, minLookYPosition, maxLookYPosition);
            manager.LookPosition.localPosition = positionOfLookPosition;
        }
        public void Jump()
        {
            if (manager.CharacterController.isGrounded == false||isJumping)
            {
                Debug.Log("Grounded");
                return;
            }
            float value = 0;
            jumpDuration = 0.25f;
            isJumping = true;
            DOTween.To(() => value, x => value = x, manager.PlayerData.JumpSpeed, jumpDuration).SetEase(Ease.InExpo).OnUpdate(() =>
            {
                totalMovePosition.y += value*Time.deltaTime;
            });
        }
        public void ApplyMovement()
        {
            manager.CharacterController.Move(totalMovePosition);
            totalMovePosition = Vector3.zero; // Reset accumulated movement
        }
    }
}

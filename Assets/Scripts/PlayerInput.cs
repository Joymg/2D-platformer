using System;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.Input
{
    public class PlayerInput : MonoBehaviour
    {
        [field: SerializeField]
        public Vector2 MovementVector { get; private set; }

        public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnToolChanged;
        public event Action<Vector2> OnMovement;
        public KeyCode jumpKey, attackKey, menuKey;
        public UnityEvent OnMenuKeyPressed;

        private void Update()
        {
            if (Time.timeScale > 0)
            {
                GetMovementInput();
                GetJumpInput();
                GetAttackInput();
                GetToolSwapInput();
            }

            GetMenuInput();
        }
        
        private void GetMovementInput()
        {
            MovementVector = GetMovementVector();
            OnMovement?.Invoke(MovementVector);
        }

        private Vector2 GetMovementVector()
        {
            return new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        }

        private void GetJumpInput()
        {
            if (UnityEngine.Input.GetKeyDown(jumpKey))
            {
                OnJumpPressed?.Invoke();
            }
            if (UnityEngine.Input.GetKeyUp(jumpKey))
            {
                OnJumpReleased?.Invoke();
            }
        }
        
        private void GetAttackInput()
        {
            if (UnityEngine.Input.GetKeyDown(attackKey))
            {
                OnAttack?.Invoke();
            }
        }
        
        private void GetToolSwapInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                OnToolChanged?.Invoke();
            }
        }
        
        private void GetMenuInput()
        {
            if (UnityEngine.Input.GetKeyDown(menuKey))
            {
                OnMenuKeyPressed?.Invoke();
            }
        }







    }
}
using System;
using Joymg.Platformer2D.Input;
using UnityEngine;

namespace Joymg.Platformer2D.AI
{
    public abstract class AIEnemy : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector { get; set; }
        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnToolChanged;
        public event Action<Vector2> OnMovement;

        public virtual void InvokeOnAttack()
        {
            OnAttack?.Invoke();
        }

        public virtual void InvokeOnJumpPressed()
        {
            OnJumpPressed?.Invoke();
        }

        public virtual void InvokeOnJumpReleased()
        {
            OnJumpReleased?.Invoke();
        }

        public virtual void InvokeOnToolChanged()
        {
            OnToolChanged?.Invoke();
        }

        public virtual void InvokeOnMovement(Vector2 obj)
        {
            OnMovement?.Invoke(obj);
        }
    }
}
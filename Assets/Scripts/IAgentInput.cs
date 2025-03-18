using System;
using UnityEngine;

namespace Joymg.Platformer2D.Input
{
    public interface IAgentInput
    {
        public Vector2 MovementVector { get; }
        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnToolChanged;
        public event Action<Vector2> OnMovement;
    }
}
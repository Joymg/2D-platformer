using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.States
{
    public abstract class State : MonoBehaviour
    {
        [Header("State Events")] 
        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void ExitState();
    }
}
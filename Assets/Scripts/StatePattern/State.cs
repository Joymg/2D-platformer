using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.States
{
    public abstract class State : MonoBehaviour
    {
        public UnityEvent OnEnter, OnExit;

        protected abstract void EnterState();
        public abstract void UpdateState();
        protected abstract void ExitState();
    }
}
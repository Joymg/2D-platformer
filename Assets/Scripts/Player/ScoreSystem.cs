using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class ScoreSystem : MonoBehaviour
    {
        public UnityEvent<int> OnPointsValueChange;
        public UnityEvent OnPickUpPoints;
        private int _points = 0;
        
        public int Points
        {
            get => _points;
            set => _points = value;
        }

        public void Add(int amount)
        {
            Points += amount;
            OnPickUpPoints?.Invoke();
            OnPointsValueChange?.Invoke(Points);
        }
    }
}
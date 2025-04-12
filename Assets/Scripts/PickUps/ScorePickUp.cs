using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.Entities.PickUps
{
    public class ScorePickUp : PickUp
    {
        public UnityEvent OnPickUp;
        [SerializeField] public int value = 1;
        public override void Collect(Agent agent)
        {
            ScoreSystem scoreSystem = agent.GetComponent<ScoreSystem>();
            scoreSystem.Add(value);
            OnPickUp.Invoke();
            
        }
    }
}
using System;
using Joymg.Platformer2D.Input;
using Joymg.Platformer2D.States;
using UnityEngine;

namespace Joymg.Platformer2D.Entities
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] public Rigidbody2D body;
        [SerializeField] public PlayerInput agentInput;
        [SerializeField] public AgentAnimator animatorManager;
        [SerializeField] private AgentRenderer agentRenderer;

        private void Awake()
        {
            agentInput = GetComponentInParent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
            animatorManager = GetComponentInChildren<AgentAnimator>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();
        }

        private void Start()
        {
            agentInput.OnMovement += HandleMovement;
            agentInput.OnMovement += agentRenderer.FaceDirection;
            agentInput.OnJumpPressed += HandleJump;
        }

        private void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0)
            {
                if (Mathf.Abs(body.velocity.x) < 0.01f)
                {
                    animatorManager.PlayAnimation(AnimationType.Run);
                }

                body.velocity = new Vector2(input.x * 5, body.velocity.y);
            }
            else if (Mathf.Abs(body.velocity.x) > 0f)
            {
                animatorManager.PlayAnimation(AnimationType.Idle);
            }

            body.velocity = new Vector2(0, body.velocity.y);
        }

        private void HandleJump()
        {
            throw new NotImplementedException();
        }

        public void SetState(State newState, State previousState)
        {
            throw new NotImplementedException();
        }
    }
}
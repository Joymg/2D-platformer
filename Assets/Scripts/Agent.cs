using System;
using System.Collections;
using System.Collections.Generic;
using Joymg.Platformer2D.Input;
using UnityEngine;

namespace Joymg.Platformer2D.Entities
{
    public class Agent : MonoBehaviour
    {

        [SerializeField] private Rigidbody2D body;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private AgentAnimator animatorManager;
        [SerializeField] private AgentRenderer agentRenderer;
        
        private void Awake()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
            animatorManager = GetComponentInChildren<AgentAnimator>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();
        }

        private void Start()
        {
            playerInput.OnMovement += HandleMovement;
            playerInput.OnMovement += agentRenderer.FaceDirection;
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
            else
            {
                if (Mathf.Abs(body.velocity.x) > 0f)
                {
                    animatorManager.PlayAnimation(AnimationType.Idle);
                }
                body.velocity = new Vector2(0, body.velocity.y);
            }
        }
    }
}
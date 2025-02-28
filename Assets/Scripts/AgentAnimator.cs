using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joymg.Platformer2D.Entities
{
    public class AgentAnimator : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Play(string animationName)
        {
            animator.Play(animationName, -1,0f);
        }

        public void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Dead:
                    break;
                case AnimationType.Hit:
                    break;
                case AnimationType.Idle:
                    Play("Player_Idle");
                    break;
                case AnimationType.Attack:
                    break;
                case AnimationType.Run:
                    Play("Player_Run");
                    break;
                case AnimationType.Jump:
                    Play("Player_Jump");
                    break;
                case AnimationType.Fall:
                    Play("Player_Fall");
                    break;
                case AnimationType.Climb:
                    Play("Player_Climb");
                    break;
                case AnimationType.Land:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animationType), animationType, null);
            }
        }

        public void StartAnimation()
        {
            animator.enabled = true;
        }
        
        public void StopAnimation()
        {
            animator.enabled = false;
        }
    }

    public enum AnimationType
    {
        Dead,
        Hit,
        Idle,
        Attack,
        Run,
        Jump,
        Fall,
        Climb,
        Land
    }
}



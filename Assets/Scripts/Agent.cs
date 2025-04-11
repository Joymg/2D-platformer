using System;
using Joymg.Platformer2D.Detectors;
using Joymg.Platformer2D.Input;
using Joymg.Platformer2D.States;
using Joymg.Platformer2D.WeaponSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Joymg.Platformer2D.Entities
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] public AgentData_SO data;
        
        [SerializeField] public Rigidbody2D body;
        [SerializeField] public IAgentInput agentInput;
        [SerializeField] public AgentAnimator animatorManager;
        [SerializeField] private AgentRenderer agentRenderer;
        [SerializeField] public GroundDetector groundDetector;
        [SerializeField] public ClimbingDetector climbingDetector;
        [SerializeField] public Damageable damageable;

        [SerializeField] public AgentWeaponManager weaponManager;


        [Header("States")] 
        public StateFactory StateFactory;
        public State initialState;
        public State currentState = null, previousState = null;

        [Header("Events")] 
        [SerializeField] public UnityEvent OnDead;
        [field: SerializeField] private UnityEvent OnRespawnRequired { get; set; }

        private void Awake()
        {
            agentInput = GetComponentInParent<IAgentInput>();
            body = GetComponent<Rigidbody2D>();
            animatorManager = GetComponentInChildren<AgentAnimator>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();
            groundDetector = GetComponentInChildren<GroundDetector>();
            climbingDetector = GetComponentInChildren<ClimbingDetector>();
            weaponManager = GetComponentInChildren<AgentWeaponManager>();
            StateFactory = GetComponentInChildren<StateFactory>();
            damageable = GetComponent<Damageable>();

            StateFactory.InitializeStates(this);
        }

        private void Start()
        {
            agentInput.OnMovement += agentRenderer.FaceDirection;
            Initialize();
        }

        private void Initialize()
        {
            SetState(initialState);
            damageable.Initialize(data.health);

            agentInput.OnToolChanged += SwapWeapon;
        }

        private void SwapWeapon()
        {
            if (!weaponManager )
                return;
            weaponManager.SwapWeapon();
        }

        private void Update()
        {
            currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            groundDetector.CheckIsGrounded();
            currentState.FixedUpdateState();
        }
        private void HandleJump()
        {
            throw new NotImplementedException();
        }

        public void SetState(State newState)
        {
            if (!newState)
                return;
            if (currentState == newState)
                return;

            currentState?.ExitState();
            previousState = currentState;
            currentState = newState;
            currentState.EnterState();

            //DisplayState();
        }

        private void DisplayState()
        {
            Debug.Log($"Agent: {gameObject.name} now in {currentState.GetType()}");
        }

        public void GetHit()
        {
            ((AgentState)currentState).GetHit();
        }
        
        
        public void PickUp(WeaponData weaponData)
        {
            if (!weaponManager)
                return;
            
            weaponManager.PickUpWeapon(weaponData);
        }
        
        public void Die()
        {
            if (damageable.CurrentHealth > 0)
            {
                OnRespawnRequired?.Invoke();
            }
            else
            {
                ((AgentState)currentState).Die();
            }
        }

    }
}
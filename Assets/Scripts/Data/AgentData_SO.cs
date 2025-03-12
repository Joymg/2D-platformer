using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/new Data")]
public class AgentData_SO : ScriptableObject
{

    [Header("Stats")]
    public int health = 10;
    
    [Header("Movement Data")] 
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float maxSpeed = 10f;


    [Header("Jump Data")]
    public float jumpForce = 12f;
    public float defaultGravity = 2f;
    public float cutJumpGravityMultiplier = 2f;
    public float gravityMultiplier = 0.5f;

    
    [Header("Climb Data")] 
    public Vector2 climbSpeed = new(2,5);
}

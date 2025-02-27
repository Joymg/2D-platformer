using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Collider2D agentCollider;
    public LayerMask groundMask;

    public bool isGrounded = false;

    [Header("Gizmo parameters")] [Range(-2f, 2f)] [SerializeField]
    private float boxCastYOffset = -0.1f;

    [Range(-2f, 2f)] [SerializeField] private float boxCastXOffset = -0.1f;

    [Range(0f, 2f)] [SerializeField] private float boxCastWidth = 1, boxCastHeight = 1;

    [SerializeField] private Color groundedGizmosColor = Color.green, airborneGizmoColor = Color.red;

    private Vector2 BoxCastCenter => agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset);
    private Vector2 BoxCastSize => new(boxCastWidth, boxCastHeight);

    private void Awake()
    {
        if (!agentCollider)
            agentCollider = GetComponent<Collider2D>();
    }

    public void CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCastCenter, BoxCastSize, 0, Vector2.down, 0, groundMask);

        if (raycastHit.collider)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!agentCollider)
            return;

        Gizmos.color = airborneGizmoColor;
        if (isGrounded)
            Gizmos.color = groundedGizmosColor;

        Gizmos.DrawWireCube(BoxCastCenter, BoxCastSize);
    }
}
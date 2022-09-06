using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    public Collider2D bodyCollider;


    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask scenaryLayer;
    void Start()
    {
        mustPatrol = true;
    }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, scenaryLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(scenaryLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}

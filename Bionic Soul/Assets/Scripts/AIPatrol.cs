using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    private bool mustTurn;
    public Collider2D bodyCollider;


    Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask scenaryLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            Patrol();
        print(rb.velocity.x);
    }
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
           Flip();
        

        
    }
}

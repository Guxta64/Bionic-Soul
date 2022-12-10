using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public bool temVisao, paraDireita;
    private float cooldownTimer = Mathf.Infinity, timer;
    public Rigidbody2D rb;
    public GameObject ShootPreFab;
    public Transform SpawnBala;
    private float walkSpeed = -4;

    [HideInInspector]
    public Collider2D bodyCollider;
    void Awake()
    {
        gameObject.transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Patrol();
       timer -= Time.deltaTime;
       if (temVisao)
       {
           temVisao = false;
       }
       cooldownTimer += Time.deltaTime;
       if (cooldownTimer >= attackCooldown)
       {
           cooldownTimer = 0;
       }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            temVisao = true;
            GameObject tempPrefab = Instantiate(ShootPreFab, SpawnBala.position, SpawnBala.rotation);
            if (col.transform.position.x < transform.position.x) 
            {
                tempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);             
            } else if(col.transform.position.x > transform.position.x)
            {
                tempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
            }
            
        }
        if (col.CompareTag("Colisores"))
        {
            Flip();
        }
        
    }
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }
    void Flip()
    {
        gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }

}

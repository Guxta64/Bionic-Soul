using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public bool temVisao, paraDireita;
    //[SerializeField] private float damage;
    //[SerializeField] private float range, timer;
    //[SerializeField] private float colliderDistance;
    //[SerializeField] private LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private float timer, speed = 20f;
    public Rigidbody2D rb;
    private GameObject enemy;
    public GameObject ShootPreFab;
    public Transform SpawnBala;
   

    //Referencias
    private Animator anim;
    private Health playerHealth;
    private GameObject playerH;
    void Awake()
    {
        enemy = GameObject.Find("Enemy");
        playerH = GameObject.Find("Player");
        playerHealth = playerH.GetComponent<Health>();
        

        // Update is called once per frame
       
    }

    void Update()
    {
       timer -= Time.deltaTime;
       if (temVisao)
       {
           Instantiate(ShootPreFab, SpawnBala.position, SpawnBala.rotation);
           temVisao = false;
       }
       cooldownTimer += Time.deltaTime;
       if (cooldownTimer >= attackCooldown)
       {
           cooldownTimer = 0;
       }
       if (temVisao)
       {
            print("alo");
           paraDireita = true;
           if (transform.localScale.x < 0)
           {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
           }
       }
       else if (!temVisao)
       {
           paraDireita = false;
           if (transform.localScale.x > 0)
           {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
           }
       }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            paraDireita = true;            
            temVisao = true;
            Instantiate(ShootPreFab, SpawnBala.position, SpawnBala.rotation);
            
        }
    }
    /*private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(timer = 0)
            {
                temVisao = true;
                timer = 1000;
            }
        }
    }*/
    private void OnTriggerExit2D(Collider2D col)
    {
        temVisao = false;
    }
}

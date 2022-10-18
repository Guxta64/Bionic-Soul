using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public bool temVisao, paraDireita;
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
    }

}

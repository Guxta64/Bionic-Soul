using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulleta : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 1;
    private GameObject enemy;
    private Enemy enemyScript;

    private GameObject player;
    private Player playerScript;
    public GameObject tutorial_3, tutorial_4;
    private Health healthScript;

    //
    void Start()
    {
        tutorial_3 = GameObject.Find("Tutorial (3)");
        tutorial_4 = GameObject.Find("Tutorial (4)");
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();

        if (playerScript.paraDireita) {

            rb.velocity = transform.right * speed;

        }else if (!playerScript.paraDireita) {

            transform.localScale = new Vector3(-0.04608959f, 0.04608959f, 0.04608959f);
            rb.velocity = transform.right * -speed;

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
            enemyScript = enemy.GetComponent<Enemy>();


            //Kill da espada + inimigo
            Destroy(collision.gameObject);        
            tutorial_3.SetActive(false);
            tutorial_4.SetActive(true);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
    }
    
} 
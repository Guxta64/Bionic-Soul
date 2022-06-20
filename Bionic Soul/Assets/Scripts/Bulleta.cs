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

    //
    void Start()
    {
        rb.velocity = transform.right * speed;
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
            enemyScript.enemyHP -= damage;


            //Kill da espada + inimigo
            //Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
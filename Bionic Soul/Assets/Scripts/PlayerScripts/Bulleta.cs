using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulleta : MonoBehaviour
{
    public float speed = 15000f;
    public Rigidbody2D rb;
    public float damage = 1;
    private GameObject enemy;
    private Enemy enemyScript;

    private GameObject player;
    private Player playerScript;
    public GameObject tutorial_3, tutorial_4, inimigoTutorial;
    private Health healthScript;
    void Start()
    {
        tutorial_3 = GameObject.Find("Tutorial (3)");
        tutorial_4 = GameObject.Find("Tutorial (4)");
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            Destroy(inimigoTutorial);
        }
    }
    
} 
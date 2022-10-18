using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f, damage;
    private Enemy enemySCR;
    GameObject enemy;    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Inimigo");
        enemySCR = enemy.GetComponent<Enemy>();     
    }

    // Update is called once per frame
    void Update()
    {            
    }
}

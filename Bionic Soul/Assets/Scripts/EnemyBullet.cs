using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f, damage;
    private Enemy enemySCR;
    GameObject enemy;
    private AIPatrol ScriptPT;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Inimigo");
        enemySCR = enemy.GetComponent<Enemy>();     
    }

    // Update is called once per frame
    void Update()
    {            
        print(enemySCR.paraDireita);

      //  print(enemySCR);
        if ()
        {
            rb.velocity = transform.right * speed;
            transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }
        else if (!enemySCR.paraDireita)
        {
            transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            rb.velocity = transform.right * -speed;
        }
    }
}

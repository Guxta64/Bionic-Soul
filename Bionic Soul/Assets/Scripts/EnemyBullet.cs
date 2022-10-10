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
      //  print(enemySCR);
        if (enemySCR.paraDireita)
        {
            print("lado um");
            rb.velocity = transform.right * speed;
            transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }
        else if (!enemySCR.paraDireita)
        {
            print("lado outro");
            transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            rb.velocity = transform.right * -speed;
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaDeVisao : MonoBehaviour
{

    private GameObject enemy;
    private Enemy enemySCR;
    [SerializeField]
    private float timer;

    // Start is called before the first frame update
    void Start() {

        enemy = GameObject.Find("Enemy");
        enemySCR = enemy.GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
            timer = 1;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           
            if (timer <= 0)
            {
                enemySCR.temVisao = true;
                timer = 1000;
            }
            print("Caralhooooooo");

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            enemySCR.temVisao = false;

        }


    }



}*/

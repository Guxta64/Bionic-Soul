using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaDeVisao : MonoBehaviour
{

    private GameObject enemy;
    private Enemy enemySCR;

    // Start is called before the first frame update
    void Start() {

        enemy = GameObject.Find("Enemy");
        enemySCR = enemy.GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        


    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            enemySCR.temVisao = true;
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



}

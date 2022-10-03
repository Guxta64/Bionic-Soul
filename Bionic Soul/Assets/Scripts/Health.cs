using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject enemy;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void takeDamageShot()
    {

        currentHealth--;

    }


    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            print("recebeudano");
            currentHealth--;
            if(currentHealth >= 0)
            {
                enemy.SetActive(false);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void takeDamageShot()
    {
        currentHealth--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaInimigo"))
        {
            currentHealth--;
            if(currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }


}

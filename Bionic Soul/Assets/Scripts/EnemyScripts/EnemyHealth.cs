using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float staringHealth;
    public float currentHealth;
    public GameObject enemy;
    void Awake()
    {
        currentHealth = staringHealth;
    }
    public void takeDamageShot()
    {
        currentHealth--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            currentHealth--;
            if(currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

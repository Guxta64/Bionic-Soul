using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float staringHealth;
    public float currentHealth;
    public GameObject enemy;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthbar;
    void Awake()
    {
        totalHealthBar.fillAmount = enemyHealth.currentHealth / 3;
        currentHealth = staringHealth;
    }
    private void Update()
    {
        currentHealthbar.fillAmount = enemyHealth.currentHealth / 3;
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

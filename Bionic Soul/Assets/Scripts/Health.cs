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

    public void TakeDamage(float _damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            //Dano do inimigo não está funcionando
        }
        else
        {
            //plyer dead
        }
    }
    public void takeDamageShot()
    {

        currentHealth--;

    }


    private void Update()
    {
        
    }
}

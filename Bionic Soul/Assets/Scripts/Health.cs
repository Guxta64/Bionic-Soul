using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            //Dano do inimigo n�o est� funcionando
        }
        else
        {
            //plyer dead
        }
    }
    private void Update()
    {
        
    }
}

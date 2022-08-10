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


    private void Update()
    {
        
    }
}

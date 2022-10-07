using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Enemy : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject enemy;
    //materiais
    public Material matWhite;
    public Material matDefault;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;

        sr = GetComponent<SpriteRenderer>();
        matDefault = sr.material;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            currentHealth--;
            matDefault = matWhite;
            sr.material = matWhite;
            if (currentHealth == 0)
            {
                Destroy(enemy);
            }
            else
            {
                Invoke("ResetMaterial", 1f);
            }
        }
    }
    void ResetMaterial()
    {
        matWhite = matDefault;        
        sr.material = matDefault;

    }
    public void takeDamageShot()
    {

        currentHealth--;

    }

}

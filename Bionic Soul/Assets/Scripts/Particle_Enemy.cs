using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Enemy : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject enemy;
    //materiais
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;

        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            currentHealth--;
            sr.material = matWhite;
            if (currentHealth == 0)
            {
                Destroy(enemy);
            }
            else
            {
                Invoke("ResetMaterial", 5f);
            }
        }
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }
    public void takeDamageShot()
    {

        currentHealth--;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public bool temVisao;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private float tempo;

    //Referencias
    private Animator anim;
    private Health playerHealth;
    private GameObject playerH;
     void Awake()
    {

        playerH = GameObject.Find("Player");
        playerHealth = playerH.GetComponent<Health>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (temVisao)
        {
            //coloca aqui o que tu quer que ele faça quando entra na vis�o do inimigo
            playerHealth.currentHealth -= 1;
            temVisao = false;

        }
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
        }
    }


}

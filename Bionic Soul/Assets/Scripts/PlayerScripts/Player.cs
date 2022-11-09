using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject bulletPreFab, gameover, enemy, pause;
   
    public SpriteRenderer spritex;
    public float speedX, jumpStrength;
    public float horizontal;
    private Rigidbody2D body;
    private GameController gc;
    private bool groundCheck;
    private Transform foot;
    public Transform swordSpawn;
    public GameObject bulletPrefab;
    Grounded grundchereca;
    Animator anim;
    PhotonView view;
    public bool paraDireita;
    public float firerate, bulletforce;
    float nextfire;
    Health healthSCP;

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        grundchereca = GetComponent<Grounded>();
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        foot = GameObject.FindGameObjectWithTag("groundCheck").transform;
        view = GetComponent<PhotonView>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            controls();
        }
        if (currentHealth <= 0)
        {
            gameover.SetActive(true);
            enemy.SetActive(false);
            Time.timeScale = 0;
            Destroy(this.gameObject);
            
        }
        #region controles de movimentação
        controls();
        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        

            if (Input.GetButtonDown("D"))//direita
            {
                paraDireita = true;
                if (transform.localScale.x < 0)
                {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }

            }
            else if (Input.GetButtonDown("A"))//esquerda
            {
                paraDireita = false;
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
        }
        #endregion


    }
    #region controles de bala e animação
    void controls()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 || horizontal < 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        body.velocity = new Vector2(horizontal * speedX, body.velocity.y);
        if (Input.GetButtonDown("W") && groundCheck)
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
            anim.SetTrigger("Jump");
        }
       
        #endregion
        #region Controles de bala
        if (Input.GetButtonDown("Jump"))
        {
            if(Time.time > nextfire)
            {
            nextfire = Time.time + firerate; 
            GameObject tempPreFab = Instantiate(bulletPrefab, swordSpawn.position, swordSpawn.rotation);
                tempPreFab.transform.parent = null;
                if (Input.GetButtonDown("D") || paraDireita)//Se o player estiver olhando pra direita a bala vai ter valor +
                {
                   tempPreFab.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
                }
                else if (Input.GetButtonDown("A") || !paraDireita)//Se o player estiver olhando pra direita a bala vai ter valor -
                {
                    tempPreFab.GetComponent<Rigidbody2D>().AddForce(transform.right * -1000);
                }
                
            }

        }
        #endregion

    }
    public void SetGroundCheck(bool grounded)
    {
        groundCheck = grounded;    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaInimigo"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
        }
    }
}
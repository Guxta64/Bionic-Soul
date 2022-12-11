using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject CanvasPausa;
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject bulletPreFab, gameover, enemy, pause, win, bulletPrefab, jogo;
    public SpriteRenderer spritex;
    public float speedX, jumpStrength, horizontal, firerate, bulletforce;
    [SerializeField]private Rigidbody2D body;
    private bool groundCheck, pausado;
    public Transform swordSpawn;
    Animator anim;
    public bool paraDireita, controlando;
    float nextfire;
    public bool despausar() { return pausado; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        controls();
        if (currentHealth <= 0)
        {
            gameover.SetActive(true);
            jogo.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
        #region controles de movimentação
        controls();
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
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
        if (collision.CompareTag("Win"))
        {
            win.SetActive(true);
            jogo.SetActive(false);
        }
        if (collision.CompareTag("BalaInimigo"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        SetGroundCheck(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SetGroundCheck(false);
    }

}
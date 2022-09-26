using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Player : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        grundchereca = GetComponent<Grounded>();
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        foot = GameObject.FindGameObjectWithTag("groundCheck").transform;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            print("isMIne");
            controls();

        if (Input.GetButtonDown("D")) 
        {
            paraDireita = true;

            if(transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }

        }
        else if (Input.GetButtonDown("A"))
        {
            paraDireita = false;
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }

        }
        }
       
        
    }
    void controls()
    {  // Left and Right UwU
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal> 0||horizontal < 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        body.velocity = new Vector2(horizontal * speedX, body.velocity.y);

        //Projectil Rotation
        //bulletPrefab.GetComponent<GameObject>().speed = -1;
        //-----
        /*if (horizontal > 0) //direita
        {
          
        }
        if (horizontal < 0) //esquerda
        {

        }*/


        // Jump
        //groundCheck = Physics2D.OverlapCircle(foot.position, 0.03f);

        if (Input.GetButtonDown("W") && groundCheck)
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
        //BOTÃO DE GATINHO PRA ARMA
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("shoot", true);
            Shoot();
        }
        else
        {
            anim.SetBool("shoot", true);
        }
    }
    public void SetGroundCheck(bool grounded)
    {
        print(grounded);
        groundCheck = grounded;
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, swordSpawn.position, swordSpawn.rotation);
    }


    //CENAS
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //INIMIGO
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Death");
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Sexo"))
        {
            SceneManager.LoadScene("WinScene");
        }
        if (collision.gameObject.CompareTag("Game"))
        {
            SceneManager.LoadScene("Game");
        }
    }*/
}
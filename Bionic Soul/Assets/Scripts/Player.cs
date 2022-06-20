using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private SpriteRenderer spritex;
    public float speedX, jumpStrength;
    public float horizontal;
    private Rigidbody2D body;
    private GameController gc;
    private bool groundCheck;
    private Transform foot;
    public Transform swordSpawn;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        foot = GameObject.FindGameObjectWithTag("groundCheck").transform;

    }

    // Update is called once per frame
    void Update()
    {
        controls();
    }
    void controls()
    {  // Left and Right UwU
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speedX, body.velocity.y);

        //Projectil Rotation
        //bulletPrefab.GetComponent<GameObject>().speed = -1;
        //-----
        if (horizontal > 0) //direita
        {

            transform.rotation = new Quaternion(0f, 0f, 0f, 0);
            //BulletPrefab.speed = speed * -1;

        }
        if (horizontal < 0) //esquerda
        {

            transform.rotation = new Quaternion(0f, 180f, 0f, 0);

        }


        // Jump
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.03f);

        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
        //BOTÃO DE GATINHO PRA ARMA
        if (Input.GetButtonDown("Fire1"))
        {
            //GameObject tempprefab = Instantiate(bulletPrefab) as GameObject;
            //tempprefab.transform.position = gameObject.transform.position;
            Shoot();
        }
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
            gc.GameOver();

        }
        if (collision.gameObject.CompareTag("Sexo"))
        {
            SceneManager.LoadScene("WinScene");
            gc.WinScene();
        }
        if (collision.gameObject.CompareTag("Game"))
        {
            SceneManager.LoadScene("Game");
            gc.Game();
        }
    }*/
}
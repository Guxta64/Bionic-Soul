using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedX, jumpStrength;
    private float horizontal;
    private Rigidbody2D body;
    //private GameController gc;
    private bool groundCheck;
    private Transform foot;
    //public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //gc = FindObjectOfType(typeof(GameController)) as GameController;
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

        // Jump
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.03f);

        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }

        //BOT�O DE GATINHO PRA ARMA
        /*if (Input.GetButtonDown("Fire1"))
        {
            GameObject tempprefab = Instantiate(bullet) as GameObject;
            tempprefab.transform.position = transform.position;
        }*/
    }

    //MORTE PELO ENEMEGO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
            //gc.GameOver();

        }
    }
}
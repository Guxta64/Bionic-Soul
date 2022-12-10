using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Playerteste : MonoBehaviourPunCallbacks
{
    public GameObject bulletPreFab, gameover, enemy, pause, vitoria, lose, winC, jogo;
    private Playerteste hero;
    public SpriteRenderer spritex;
    public float speedX, jumpStrength, horizontal, pontos;
    private Rigidbody2D body;
    private bool groundCheck;
    Animator anim;
    PhotonView view;
    public Text pontuacao;

    private void Awake()
    {

    }
    void Start()
    {
        hero = GetComponentInParent<Playerteste>();
        anim = GetComponent<Animator>();
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        Time.timeScale = 1;
        GameObject tutut = GameObject.Find("Text");
        pontuacao = tutut.GetComponent<Text>();
        vitoria = GameObject.Find("CanvasVitoria");
        vitoria.SetActive(false);
        winC = GameObject.Find("Win");
        jogo = GameObject.Find("Jogo");
    }

    void Update()
    {

        if (view.IsMine)
        {

            #region controles de movimentação
            controls();
            if (Input.GetButtonDown("W") && groundCheck)
            {
                body.velocity = new Vector2(body.velocity.x, jumpStrength);
                anim.SetTrigger("Jump");
            }

            if (Input.GetButtonDown("D"))//direita
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }

            }

            else if (Input.GetButtonDown("A"))//esquerda
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
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
       

        #endregion
        
    }
    public void SetGroundCheck(bool grounded)
    {
        groundCheck = grounded;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.CompareTag("Moeda"))
            {
                pontos++;
                pontuacao.text = ($"Pontos: {pontos}/10");
                GameObject moeda = collision.gameObject;
                destrui(moeda);
                
            }
            if (collision.CompareTag("WinC") && pontos >= 10)
            {
                print("colidiu");
                Win();
            }
        }
     }   
 
    public void destrui(GameObject Ponto)
    {
        Destroy(Ponto);
    }
    public void Win()
    {
        vitoria.SetActive(true);
        jogo.SetActive(false);
        Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        hero.SetGroundCheck(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hero.SetGroundCheck(false);
    }
}
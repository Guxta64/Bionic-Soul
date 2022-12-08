using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pontuacao : MonoBehaviour
{
    public float pontos;
    public Text pontuacao;
    Playerteste mulpl;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tutut = GameObject.Find("Text");
        pontuacao = tutut.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pontuacao.text = ($"Pontos: {pontos}/10");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mulpl.pontos = pontos++;
        }
    }
}

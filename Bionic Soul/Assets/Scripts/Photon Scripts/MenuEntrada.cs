using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField] private Text _nomeDoJogador, _nomeDaSala;
    public void CriarSala()
    {
        Conectar.Instancia.CriarSala(_nomeDoJogador.text);
        Conectar.Instancia.MudaNick(_nomeDaSala.text);
    }
    public void EntrarSala()
    {
        Conectar.Instancia.EntrarSala(_nomeDaSala.text);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField] private Text _nomeDoJogador, _nomeDaSala;
    public void CriarSala()
    {
        Conectar.Instancia.CriarSala(_nomeDaSala.text);
    }
    public void EntrarSala()
    {
        Conectar.Instancia.EntraSala(_nomeDaSala.text);
    }
}

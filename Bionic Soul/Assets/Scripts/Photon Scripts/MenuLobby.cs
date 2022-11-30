using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLobby : MonoBehaviour
{
    [SerializeField] private Text _ListadeJogadores;
    [SerializeField] private Button _comecaJogo;
    public void AtualizaLista()
    {
        _ListadeJogadores.text = Conectar.Instancia.ObterListaDeJogadores();
    }
}

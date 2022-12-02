using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _ListadeJogadores;
    [SerializeField] private Button _comecaJogo;

    [PunRPC]
    public void AtualizaLista()
    {
        _ListadeJogadores.text = Conectar.Instancia.ObterListaDeJogadores();
        _comecaJogo.interactable = Conectar.Instancia.DonoDaSala();
    }
}

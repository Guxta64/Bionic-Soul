using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private MenuEntrada _menuEntrada;
    [SerializeField] private MenuLobby _menuLobby;

    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false); 
        _menuLobby.gameObject.SetActive(false); 
    }
    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);
    }
    public override void OnJoinedRoom()
    {
        MudaMenu(_menuLobby.gameObject);
        _menuLobby.photonView.RPC("AtualizaLista", RpcTarget.All);
    }
    public void MudaMenu(GameObject Menu)
    {
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);
        Menu.SetActive(true);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        _menuLobby.AtualizaLista();
    }
    public void SairDoLobby()
    {
        Conectar.Instancia.SairDoLobby();
        MudaMenu(_menuEntrada.gameObject);
    }
    public void ComecaJogo(string nomeCena)
    {
        Conectar.Instancia.photonView.RPC("ComecaJogo", RpcTarget.All, nomeCena);
    }
}

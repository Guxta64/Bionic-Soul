using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Conectar : MonoBehaviourPunCallbacks
{
    public static Conectar Instancia { get; private set; }
    private void Awake()
    {
        if(Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectou");
    }
    public void CriarSala(string nomesala)
    {
        PhotonNetwork.CreateRoom(nomesala);
    }
    public void EntrarSala(string nomesala)
    {
        PhotonNetwork.JoinRoom(nomesala);
    }
    public void MudaNick(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }
}

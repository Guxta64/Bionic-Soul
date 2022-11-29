using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private MenuEntrada _menuEntrada;

    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false); 
    }
    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);
    }
}

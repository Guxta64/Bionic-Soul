using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class Launcher : MonoBehaviourPunCallbacks
{
    InputField NomePlayer;
    string gamerversion = "1";
    const string playerNamePrefKey = "PlayerNamer";
    #region MonoBehavior CallBacks
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 2 });
    }
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    private void Start()
    {
        string defaultName = string.Empty;
        InputField _inputFielf = this.GetComponent<InputField>();
        if (_inputFielf != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputFielf.text = defaultName;
            }
        }
        PhotonNetwork.NickName = defaultName;
    }
    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(playerNamePrefKey, value);
    }
    #endregion
    public void Connnect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gamerversion;
        }
    }
}

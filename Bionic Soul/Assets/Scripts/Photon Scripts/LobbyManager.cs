using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;



public class LobbyManager : MonoBehaviourPunCallbacks
{

    public int team;
    [SerializeField]
    GameObject findMatchBtn, lobbyMatch;
    public GameObject _myPlayer1;
    public GameObject _myPlayer2;
    public GameObject prePlayer1;
    public GameObject prePlayer2;
    private Player pC;
    string playerName;

    public TMP_InputField _intPlayerName;
    public string _strPlayerName;
    void Start()
    {
        findMatchBtn.SetActive(false);


        _intPlayerName.text = _strPlayerName;

        prePlayer1.SetActive(false);
        prePlayer2.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        print("Connected");

        lobbyMatch.SetActive(false);
        findMatchBtn.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.AutomaticallySyncScene = true;


    }
    public void FindMatch()
    {

        if (_intPlayerName.text != "")
        {
            PhotonNetwork.NickName = _intPlayerName.text;


        }
        else
        {
            PhotonNetwork.NickName = _strPlayerName;
        }

        findMatchBtn.SetActive(true);
        lobbyMatch.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();

        print("Procurando por server");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        MakeRoom();
    }

    public void StopSearch()
    {
        findMatchBtn.SetActive(false);
        lobbyMatch.SetActive(true);

        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        print("Conexão cancelada");
    }



    void MakeRoom()
    {
        int randomRoomName = Random.Range(0, 5000);
        RoomOptions roomOptions =
        new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };


        PhotonNetwork.CreateRoom("RoomName_" + randomRoomName, roomOptions);
        print("Sala criada");

        team = 1;




    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
    


        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {

            print(PhotonNetwork.CurrentRoom.PlayerCount + "/2 Starting Game");
            DontDestroyOnLoad(this.gameObject);

            team = 2;
            PhotonNetwork.LoadLevel(1);


            prePlayer1.SetActive(true);
            prePlayer2.SetActive(true);

        }

    }

    public void OnValueChanged()
    {
        print(_intPlayerName.text);

    }

}
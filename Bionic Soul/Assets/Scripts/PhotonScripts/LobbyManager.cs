using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel, roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    public GameObject playerPreFab;
    public Transform spawnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void OnclickCreate()
    {
        if(roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 2 });
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
        UpdatePlayerList();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }

        UpdateRoomList(roomList);
    }
    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();
        foreach(RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnLeftRoom()
    {

    }
    void UpdatePlayerList()
    { 
            foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                 Instantiate(playerPreFab, spawnPlayer);

            }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class RoomItem : MonoBehaviour
{
    public Text roomName;
    LobbyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}

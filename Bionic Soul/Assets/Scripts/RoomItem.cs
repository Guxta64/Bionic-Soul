using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    LobbyManager manager;
    // Start is called before the first frame update
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }
    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}

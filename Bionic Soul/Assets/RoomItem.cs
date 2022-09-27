using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    // Start is called before the first frame update
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
}

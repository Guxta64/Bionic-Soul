using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createImput;
    public InputField joinImput;
    // Start is called before the first frame update
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createImput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinImput.text);
    }
    public void OnJoinedRooms()
    {
        PhotonNetwork.LoadLevel("Game");
    }
 
}

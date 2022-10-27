using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;
    public GameObject painelLobby, painelCon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickConnect()
    {
        if(usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Conectando...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {        
        painelCon.SetActive(false);
        painelLobby.SetActive(true);

    }
}

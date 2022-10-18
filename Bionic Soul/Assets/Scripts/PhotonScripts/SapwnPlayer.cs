using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SapwnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public Transform SpawnPlayer;
    // Start is called before the first frame update
    void Start()
    {
       GameObject player =   PhotonNetwork.Instantiate(playerPrefab.name, SpawnPlayer.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

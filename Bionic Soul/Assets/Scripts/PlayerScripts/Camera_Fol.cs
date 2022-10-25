using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Camera_Fol : MonoBehaviour
{
    public float FollowSpeed = 5f;
    public float yoffset = 3f;
    public Transform target;
    public bool SeguirCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            cameraseguir();
    }
    void cameraseguir()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

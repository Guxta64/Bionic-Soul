using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarMulti : MonoBehaviour
{
    [SerializeField] private Playerteste playermul;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    public Transform target;
    public float FollowSpeed = 5f;
    public float yoffset = 3f;
    void Start()
    {
        totalHealthBar.fillAmount = playermul.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        barraseguir();
        currentHealthBar.fillAmount = playermul.currentHealth / 3;
    }
    void barraseguir()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player PlayerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    void Start()
    {
        totalHealthBar.fillAmount = PlayerHealth.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = PlayerHealth.currentHealth / 3;
    }
}

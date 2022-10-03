using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private SpriteRenderer currentHealthbar;
    [SerializeField] private SpriteRenderer totalHealthbar;
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
}

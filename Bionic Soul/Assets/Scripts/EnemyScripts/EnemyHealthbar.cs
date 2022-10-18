using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthbar;
    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = enemyHealth.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = enemyHealth.currentHealth / 3;
    }
}

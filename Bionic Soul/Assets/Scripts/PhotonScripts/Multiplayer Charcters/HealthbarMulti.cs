using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarMulti : MonoBehaviour
{
    [SerializeField] private Playerteste playermul;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    void Start()
    {
        totalHealthBar.fillAmount = playermul.currentHealth / 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playermul.currentHealth / 1;
    }
}

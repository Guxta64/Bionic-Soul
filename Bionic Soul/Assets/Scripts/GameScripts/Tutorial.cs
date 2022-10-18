using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial_1, tutorial_2, tutorial_3, tutorial_4, enemy, EndT;
    public int textT;
    // Start is called before the first frame update
    void Awake()
    {
        textT = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        tutorial();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            textT = textT + 1;
            Destroy(other.gameObject);
        }
    }
    void tutorial()
    {
        switch (textT)
        {
            case 1:
                tutorial_1.SetActive(false);
                tutorial_2.SetActive(true);
                break;
            case 2:
                tutorial_2.SetActive(false);
                tutorial_3.SetActive(true);
                enemydetect(true);
                break;
            case 3:
                tutorial_3.SetActive(false);
                tutorial_4.SetActive(true);
                
                break;
            case 4:
                break;

                
        }

    }
    void enemydetect(bool ativer)
    {
        if (enemy.gameObject.Equals(null))
        {
            print("sem nada ");
            EndT.SetActive(true);
            textT++;

        }
    }
    public void voltamenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

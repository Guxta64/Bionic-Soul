using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;

public class ButtonMaster : MonoBehaviour
{
    public GameObject pausa, Objects, Menu, Config, Tutorial;
=======

public class ButtonMaster : MonoBehaviour
{
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
    public void confirmClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void opcoes()
    {
        Menu.SetActive(false);
        Config.SetActive(true);
    }
    public void voltarMenuOpcoes()
    {
        Menu.SetActive(true);
        Config.SetActive(false);
    }
=======
>>>>>>> Stashed changes
}

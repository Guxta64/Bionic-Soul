using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMestre : MonoBehaviour
{
    public GameObject pausa, Objects, Menu, Config, Tutorial, Fps, Musica, slider, brilho, BotaoBrilho;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CoOp()
    {
        SceneManager.LoadScene("Loading");
    }
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
    public void FPS()
    {
        Fps.SetActive(false);
    }
    public void Mute()
    {
        Musica.SetActive(false);
        slider.SetActive(false);
    }
}

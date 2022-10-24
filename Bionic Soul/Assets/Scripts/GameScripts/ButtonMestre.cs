using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMestre : MonoBehaviour
{
    public GameObject pausa, Objects, Menu, Config, Tutorial, slider, playerprefab;
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
        SceneManager.LoadScene("ConnectedToServer");
    }
    public void confirmClick()
    {
        SceneManager.LoadScene("Game");
        DontDestroyOnLoad(Instantiate(playerprefab, new Vector3(185, -10, 0), Quaternion.identity));
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
        //Fps.SetActive(false);
    }
    public void Mute()
    {
        //Musica.SetActive(false);
        slider.SetActive(false);
    }
    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

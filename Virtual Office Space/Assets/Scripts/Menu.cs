using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject inGameMenu;
    GameObject levelSelect;
    GameObject mainMenu;
    bool inGameMenuActive = false;

    void Start()
    {
        levelSelect = GameObject.FindGameObjectWithTag("Level Select");
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGameMenuActive == false)
        {
            inGameMenu.SetActive(true);
            inGameMenuActive = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && inGameMenuActive == true)
        {
            inGameMenu.SetActive(false);
            inGameMenuActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void MainMenu()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LevelSelect()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

	public void LoadBeach()
    {
        SceneManager.LoadScene("Beach");
        inGameMenu.SetActive(false);
    }

    public void LoadCity()
    {
        SceneManager.LoadScene("Apartment");
        inGameMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}

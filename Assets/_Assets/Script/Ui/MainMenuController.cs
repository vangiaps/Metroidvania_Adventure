using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;

    private void Start()
    {
        Time.timeScale = 0f;
        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        if (mainMenu != null)
        {
            mainMenu.SetActive(false);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Đang thoát game...");
        Application.Quit(); 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject charater2;
    [SerializeField] private GameObject Ui;

    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        GameObject.DontDestroyOnLoad(Ui);
    }

    public void displayCharater()
    {
        if (charater2 != null)
        {
            charater2.SetActive(true);
        }
    }

    public void LoadScene(string gameScene)
    {
        StartCoroutine(LoadSceneAsync(gameScene));
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
        yield return null;
    }
}

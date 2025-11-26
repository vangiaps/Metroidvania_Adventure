using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject charater2;

    public int _maxHealth = 6;
    public int currentHealth;
    private void Awake()
    {
        if (instance == null)
        {
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentHealth = _maxHealth;

    }
    private void Start()
    {
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

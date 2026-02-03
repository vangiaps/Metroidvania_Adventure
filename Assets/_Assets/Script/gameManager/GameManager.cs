using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject charaters;
    [SerializeField] private List<GameObject> listCharaters = new();

    public int coin = 0;

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
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    protected void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ClearList();
        ApproveTheList();
    }
    private void ApproveTheList()
    {
        if (charaters == null)
        {
            charaters = GameObject.Find("Charaters");
        }
        foreach (Transform child in charaters.transform)
        {
            listCharaters.Add(child.gameObject);
        }
    }
    private void ClearList()
    {
        listCharaters.Clear();
    }
    public void displayCharater(int index)
    {
        if (listCharaters[index] != null)
        {
            listCharaters[index].SetActive(true);
            CharacterSwitcher.instance.unlockCharaters[index] = true;
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

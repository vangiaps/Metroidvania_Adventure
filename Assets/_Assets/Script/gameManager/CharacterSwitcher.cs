using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public static CharacterSwitcher instance;
    [SerializeField] private List<GameObject> player;
    private int currentIndex = 0;
    public List<bool> unlockCharaters = new();

    private bool charater1 = true;
    private bool charater2 = false;
    private bool charater3 = false;

    private void Start()
    {
        instance = instance != null ? instance : this;
        DontDestroyOnLoad(gameObject);
        foreach (var p in player)
        {
            if (p != null) p.SetActive(false);
        }
        if(player.Count > 0)
        {
            player[0].SetActive(true);
            currentIndex = 0;
        }
        unlockCharaters.Add(charater1);
        unlockCharaters.Add(charater2);
        unlockCharaters.Add(charater3);
        for (int i = 0; i < unlockCharaters.Count; i++) { Debug.Log("Flag " + i + ": " + unlockCharaters[i]); }
    }
    private void Update()
    {
        if (InputManager.Instance.one() && unlockCharaters[0]) ActivePlayer(0);
        if (InputManager.Instance.two() && unlockCharaters[1]) ActivePlayer(1);
        if (InputManager.Instance.three() && unlockCharaters[2]) ActivePlayer(2);
    }
    private void ActivePlayer(int newIndex)
    {
        if (newIndex < 0 || newIndex >= player.Count) return;

        if (newIndex == currentIndex) return;

        GameObject oldChar = player[currentIndex];
        GameObject newChar = player[newIndex];

        Vector3 oldPos = oldChar.transform.position;
        Quaternion oldRot = oldChar.transform.rotation;

        oldChar.SetActive(false);

        newChar.transform.position = oldPos;
        newChar.transform.rotation = oldRot;

        newChar.SetActive(true);

     
        var vCam = FindAnyObjectByType<CinemachineVirtualCamera>();
        if (vCam != null)
        {
            vCam.Follow = newChar.transform;
            vCam.LookAt = newChar.transform;
        }

        currentIndex = newIndex;
    }
}

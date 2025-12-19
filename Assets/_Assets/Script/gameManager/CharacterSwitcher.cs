using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> player;
    private int currentIndex = 0;

    private void Awake()
    {
        foreach (var p in player)
        {
            if (p != null) p.SetActive(false);
        }
        if(player.Count > 0)
        {
            player[0].SetActive(true);
            currentIndex = 0;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (InputManager.Instance.one()) ActivePlayer(0);
        if (InputManager.Instance.two()) ActivePlayer(1);
        if (InputManager.Instance.three()) ActivePlayer(2);
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

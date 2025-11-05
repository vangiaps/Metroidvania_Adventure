using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject charater2;

    public void displayCharater()
    {
        if (charater2 != null)
        {
            charater2.SetActive(true);
        }
    }
}

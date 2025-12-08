using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    [SerializeField] private GameObject tentacle;

    private void Start()
    {
        if(tentacle == null)
        {
            tentacle = GameObject.FindGameObjectWithTag("Tentacle");
            Debug.Log("khong ti thay obj tentacle");
        }
    }

    public void Active()
    {
        tentacle.SetActive(true);
    }
     
    public void FActive()
    {
        tentacle.SetActive(false);
    }
} 

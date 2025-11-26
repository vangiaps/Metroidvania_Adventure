using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] GameObject gemPrefab;
    public List<Image> gems = new List<Image>();
    //public List<GameObject> gems = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        gems.Clear();

        for (int i=0; i< maxHealth; i++)
        {
            if (gemPrefab != null)
            {
                GameObject newGem = Instantiate(gemPrefab, transform, false);

                newGem.transform.localScale = Vector3.one;
                gems.Add(newGem.GetComponent<Image>());
            }
        }

    }

    public void UpdateHp(int currentHP)
    {
        if (gems == null || gems.Count == 0) Debug.Log("sdada" + gems.Count);
        for (int i = 0; i < gems.Count; i++)
        {

            if (i < currentHP)
                gems[i].enabled = true;   // hiện ngọc
            else
                gems[i].enabled = false;  // ẩn ngọc
            //Setup(currentHP);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Image[] gems;

    public void UpdateHp(int currentHP)
    {
        for(int i = 0; i < gems.Length; i++)
        {
            if (i < currentHP)
                gems[i].enabled = true;   // hiện ngọc
            else
                gems[i].enabled = false;  // ẩn ngọc
        }
    }
}

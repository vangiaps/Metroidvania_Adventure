using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateDoorUI(int currentScore, int requiredScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"{currentScore} / {requiredScore}";

            if (currentScore >= requiredScore)
            {
                scoreText.color = Color.green;
            }
            else
            {
                scoreText.color = Color.white; 
            }
        }
    }
}

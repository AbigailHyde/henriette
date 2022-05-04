using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static void GameOver(int currentScore)
    {
        if (PlayerPrefs.GetFloat("HighScore",0) < currentScore) {
            
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
        
    }
}

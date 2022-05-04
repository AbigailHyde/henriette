using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClosingScene : MonoBehaviour
{
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.GameOver(GameManager.runningTotal);
    }

    // Update is called once per frame
    void Update()
    {
        totalText.text = GameManager.runningTotal + " chicks captured";
        highScoreText.text = "high score: " + PlayerPrefs.GetFloat("HighScore", 0);
    }
}

//GameManager.runningTotal

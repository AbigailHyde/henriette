using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public bool isTimerActive;
    public static float timeRemaining = 120; //sets timer to 2 minutes

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI capturedText;
    public TextMeshProUGUI totalText;

    public static GameManager Instance;

    public static int runningTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //update captured count based on captured var in PlayerController
            capturedText.text = (PlayerController.captured + "/" + (RandomChick.chickCount) + " chicks collected");
            //update count on timer
            totalText.text = runningTotal + " total";
            DisplayTime(timeRemaining);

        } else if (timeRemaining <= 0 && isTimerActive)
        {
            Debug.Log("Time's up");
            timeRemaining = 0;
            DisplayTime(timeRemaining);
            isGameActive = false;
            isTimerActive = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeRemaining > 0)
        {
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        } else
        {
            timeText.text = "0:00";
        }
        
    }

}

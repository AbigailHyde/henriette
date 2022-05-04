using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToScene2();
    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Level 1")
        {
            GameManager.runningTotal = 0;
        }
    }

    public void ChangeToScene2 ()
    {
        if (GameManager.timeRemaining <= 0)
        {
            SceneManager.LoadScene(sceneName);
            //yield return 0;
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            GameManager.timeRemaining = 120;
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

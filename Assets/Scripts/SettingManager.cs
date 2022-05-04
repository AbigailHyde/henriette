using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Button easyButton;
    public Button medButton;
    public Button hardButton;
    public Color selected;
    public Color notSelected;

    // Start is called before the first frame update
    void Start()
    {
        
        notSelected = new Color(1f, 1f, 1f);
        selected = new Color(0f, 0f, 0f);
        easyButton = GameObject.FindGameObjectWithTag("easy").GetComponent<Button>();
        medButton = GameObject.FindGameObjectWithTag("med").GetComponent<Button>();
        hardButton = GameObject.FindGameObjectWithTag("hard").GetComponent<Button>();
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (PlayerPrefs.GetFloat("Difficulty", 0) == 0)
        {
            var easycolors = easyButton.colors;
            easycolors.normalColor = selected;
            easycolors.selectedColor = selected;
            easyButton.colors = easycolors;

            var medcolors = medButton.colors;
            medcolors.normalColor = notSelected;
            medcolors.selectedColor = notSelected;
            medButton.colors = medcolors;

            var hardcolors = hardButton.colors;
            hardcolors.normalColor = notSelected;
            hardcolors.selectedColor = notSelected;
            hardButton.colors = hardcolors;

        }
        else if (PlayerPrefs.GetFloat("Difficulty", 0) == 1)
        {
            //set medium to a new color
            var easycolors = easyButton.colors;
            easycolors.normalColor = notSelected;
            easycolors.selectedColor = notSelected;
            easyButton.colors = easycolors;

            var medcolors = medButton.colors;
            medcolors.normalColor = selected;
            medcolors.selectedColor = selected;
            medButton.colors = medcolors;

            var hardcolors = hardButton.colors;
            hardcolors.normalColor = notSelected;
            hardcolors.selectedColor = notSelected;
            hardButton.colors = hardcolors;
        }
        else if (PlayerPrefs.GetFloat("Difficulty", 0) == 2)
        {
            //set hard to a new color
            var easycolors = easyButton.colors;
            easycolors.normalColor = notSelected;
            easycolors.selectedColor = notSelected;
            easyButton.colors = easycolors;

            var medcolors = medButton.colors;
            medcolors.normalColor = notSelected;
            medcolors.selectedColor = notSelected;
            medButton.colors = medcolors;

            var hardcolors = hardButton.colors;
            hardcolors.normalColor = selected;
            hardcolors.selectedColor = selected;
            hardButton.colors = hardcolors;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("Difficulty"));
    }

    public void SetEasy()
    {
        PlayerPrefs.SetFloat("Difficulty", 0);
        ChangeColor();
    }

    public void SetMedium()
    {
        PlayerPrefs.SetFloat("Difficulty", 1);
        ChangeColor();
    }

    public void SetHard()
    {
        PlayerPrefs.SetFloat("Difficulty", 2);
        ChangeColor();
    }

}

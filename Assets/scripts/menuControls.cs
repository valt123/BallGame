using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControls : MonoBehaviour
{
    bool HighScoreToggle = false;
    bool OptionsToggle = false;
    Rect scoreRect = new Rect(Screen.width / 4, 100, 200, 120);
    Rect optionsRect = new Rect(Screen.width / 4, 100, 200, 120);

    int highscoreLevel;
    float highscoreScore;
    float highScoreTimer;

    float audioSettings;

    private void Start()
    {
        useGUILayout = true;
        GetHighScore();
    }

    void GetOptions()
    {
        audioSettings = PlayerPrefs.GetFloat("AudioVolume", 0.5f);
        audioSettings = Mathf.Clamp(audioSettings, 0f, 1f);
    }

    void GetHighScore()
    {
        highscoreLevel = PlayerPrefs.GetInt("HighscoreLevel", 0);
        highScoreTimer = PlayerPrefs.GetFloat("HighscoreTimer", 0);
        highscoreScore = PlayerPrefs.GetFloat("HighscoreScore", 0);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4), Screen.width / 2, 100), "Play"))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 110), Screen.width / 2, 100), "Options"))
        {
            if (OptionsToggle == false)
            {
                OptionsToggle = true;
            }

            else
            {
                OptionsToggle = false;
            }
        }
        if (OptionsToggle == true)
        {
            optionsRect = GUI.Window(0, optionsRect, OptionsWindow, "Options");
        }


        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 220), Screen.width / 2, 100), "Highscores"))
        {

            if (HighScoreToggle == false)
            {
                HighScoreToggle = true;
            }

            else
            {
                HighScoreToggle = false; 
            }
        }

        if (HighScoreToggle == true)
        {
            scoreRect = GUI.Window(1, scoreRect, HighScoreWindow, "Highscores");
        }

        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 330), Screen.width / 2, 100), "Quit"))
        {
            Application.Quit();
        }
    }

    void HighScoreWindow(int windowID)
    {
        GUI.skin.label.fontSize = 15;
        GUI.Label(new Rect(5, 15, 150, 20), "Best level: " + highscoreLevel);
        GUI.Label(new Rect(5, 40, 150, 20), "Best score: " + highscoreScore);
        GUI.Label(new Rect(5, 65, 150, 20), "Best time: " + Mathf.RoundToInt(highScoreTimer));

        if (GUI.Button(new Rect(10,90, 50, 20), "Reset"))
        {
            PlayerPrefs.DeleteKey("HighscoreLevel");
            PlayerPrefs.DeleteKey("HighscoreTimer");
            PlayerPrefs.DeleteKey("HighscoreScore");

            GetHighScore();
        }

        if (GUI.Button(new Rect(140, 90, 50, 20), "Close"))
        {
            HighScoreToggle = false;
        }
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    void OptionsWindow(int windowID)
    {
        GetOptions();
        GUI.skin.label.fontSize = 15;

        GUI.Label(new Rect(10, 20, 150, 20), "Audio volume");
        audioSettings = GUI.HorizontalSlider(new Rect(10, 45, 100, 30), audioSettings, 0.0F, 1.0F);
        PlayerPrefs.SetFloat("AudioVolume", audioSettings);

        if (GUI.Button(new Rect(140, 90, 50, 20), "Close"))
        {
            OptionsToggle = false;
        }
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }
}

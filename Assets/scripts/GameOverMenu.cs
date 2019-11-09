using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    Stats Stats;
    int highscoreLevel;
    float highscoreScore;
    float highScoreTimer;

    void Start()
    {
        Stats = GameObject.Find("Stats").GetComponent<Stats>();
        GetHighScore();

        if (Stats.score > highscoreScore)
        {
            PlayerPrefs.SetFloat("HighscoreScore", Stats.score);
        }

        if (Stats.timer > highScoreTimer)
        {
            PlayerPrefs.SetFloat("HighscoreTimer", Stats.timer);
        }

        if (Stats.level > highscoreLevel)
        {
            PlayerPrefs.SetInt("HighscoreLevel", Stats.level);
        }
    }

    void GetHighScore()
    {
        highscoreLevel = PlayerPrefs.GetInt("HighscoreLevel", 0);
        highScoreTimer = PlayerPrefs.GetFloat("HighscoreTimer", 0);
        highscoreScore = PlayerPrefs.GetFloat("HighscoreScore", 0);
    }

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 20;
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, 30), "Game Over! Level: " + Stats.level + " " + "Score: " + Stats.score + " " + "Time: " + Mathf.RoundToInt(Stats.timer));
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 4 + 40, Screen.width / 2, 30), "High Score: Level: " + highscoreLevel + " " + "Score: " + highscoreScore + " " + "Time: " + Mathf.RoundToInt(highScoreTimer));

        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 110), Screen.width / 2, 100), "Try Again"))
        {
            Destroy(GameObject.Find("Stats"));
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 220), Screen.width / 2, 100), "Main Menu"))
        {
            Destroy(GameObject.Find("Stats"));
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        if (GUI.Button(new Rect(Screen.width / 4, (Screen.height / 4 + 330), Screen.width / 2, 100), "Quit"))
        {
            Application.Quit();
        }
    }
}

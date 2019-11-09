using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public float health = 100;
    public float timer = 0f;
    float nextLevel = 30;
    public Transform hpBar;
    public Vector2 timerPos = new Vector2(110,0);
    public Vector2 labelSize = new Vector2(150,50);
    public int level = 1;
    public int score;
    Rect TimerRect;
    Rect ScoreRect;
    Rect LevelRect;
    spawn spawnSc;
    Stats stats;
    public GameObject statObject;
    bool newLevel = false;

    void Start()
    {
        spawnSc = GetComponent<spawn>();
        stats = statObject.GetComponent<Stats>();
    }

    void Update()
    {
        timer += 1 * Time.deltaTime;
        NextLevelLogic();
        UpdateStats();
        hpBar.localScale = new Vector3(health / 100, 1, 1);
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        TimerRect = new Rect(timerPos, labelSize);
        ScoreRect = new Rect((timerPos + new Vector2(110,0)), labelSize);
        LevelRect = new Rect((timerPos - new Vector2(110, 0)), labelSize);
    }
    IEnumerator sleep()
    {
        yield return new WaitForSeconds(1f);
        newLevel = false;
    }

    void NextLevelLogic()
    {
        if (timer >= nextLevel)
        {
            nextLevel += 30;
            level += 1;
            spawnSc.spawnRate -= 0.03f;
            newLevel = true;
            StartCoroutine(sleep());
        }
    }

    void UpdateStats()
    {
        stats.score = score;
        stats.timer = timer;
        stats.level = level;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 20;

        GUI.Label(TimerRect,"Time: " + Mathf.RoundToInt(timer) + "(" + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighscoreTimer", 0)) + ")");
        GUI.Label(ScoreRect, "Score: " + score + "(" + PlayerPrefs.GetFloat("HighscoreScore", 0) + ")");
        GUI.Label(LevelRect, "Level: " + level + "(" + PlayerPrefs.GetInt("HighscoreLevel", 0) + ")");

        if(newLevel)
        {
            GUI.Label(new Rect((Screen.width / 2 - 50), Screen.height / 2, 100,200), "Level: " + level);
        }
    }
}
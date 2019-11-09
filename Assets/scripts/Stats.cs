using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float score;
    public float timer;
    public int level;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

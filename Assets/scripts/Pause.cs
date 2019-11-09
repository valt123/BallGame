using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (paused == false)
            {
                paused = true;
                Debug.Log(paused);
            }
            else
            {
                paused = false;
                Debug.Log(paused);
            }
        }
    }
}

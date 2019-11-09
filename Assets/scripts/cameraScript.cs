using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public SpriteRenderer playArea;

    void Update()
    {

        var orthosize = playArea.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthosize;
    }


}

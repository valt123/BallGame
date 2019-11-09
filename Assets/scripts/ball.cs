using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float damage;
    int type;
    float speed = 15;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        type = Random.Range(1, 100);
        //Debug.Log(type);

        int greenTypeMin = 0, greenTypeMax = greenTypeMin + 5; //green has 5% chance to appear
        if (RangeFind(greenTypeMin, greenTypeMax))
        {
            damage = -10;
            this.GetComponent<SpriteRenderer>().material.color = Color.green;
            this.transform.localScale = new Vector3(1,1,1);
            rb.velocity = new Vector2(0,-speed);
        }

        int blackTypeMin = greenTypeMax, blackTypeMax = blackTypeMin + 1; //Black has 1% chance to appear
        if (RangeFind(blackTypeMin, blackTypeMax))
        {
            damage = 100;
            this.GetComponent<SpriteRenderer>().material.color = Color.black;
            this.transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(0, -speed);
        }

        int blueTypeMin = blackTypeMax, blueTypeMax = blueTypeMin + 10; //blue has 10% chance to appear
        if (RangeFind(blueTypeMin, blueTypeMax))
        {
            damage = 50;
            this.GetComponent<SpriteRenderer>().material.color = new Color(0.3f,0,0);
            this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            rb.velocity = new Vector2(0, -speed);
        }

        int redTypeMin = blueTypeMax, redTypeMax = 100; //red has 86% chance to appear
        if (RangeFind(redTypeMin,redTypeMax))
        {
            damage = 20;
            this.GetComponent<SpriteRenderer>().material.color = Color.red;
            this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            rb.velocity = new Vector2(0, -speed);
        }
    }

    bool RangeFind(int min, int max)
    {
            return (type <= max && type > min);
    }
}

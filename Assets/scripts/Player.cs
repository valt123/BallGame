using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    Vector2 mousePos;
    public Camera cam;
    Vector3 hitPosition;
    bool insidePlayArea = false;
    Collider2D coll;
    SpriteRenderer sprite;
    public GameObject particlesStar;
    gameControl gameSc;
    public List<AudioSource> CatchSounds = new List<AudioSource>();
    public AudioSource catchSound1;
    public AudioSource catchSound2;
    public AudioSource catchSound3;

    void Start()
    {
        mousePos = Input.mousePosition;
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        gameSc = GameObject.Find("GameControl").GetComponent<gameControl>();

        sprite.material.color = new Color(0, 0, 1, 1);

        CatchSounds.Add(catchSound1);
        CatchSounds.Add(catchSound2);
        CatchSounds.Add(catchSound3);

        for (int i = 0; i < 3; i++)
        {
            CatchSounds[i].volume = PlayerPrefs.GetFloat("AudioVolume", 0.5f);

        }
    }
    void Update()
    {
        PlayerObjectToCursor();
        IsPlayerInsidePlayArea();
    }

    void PlayerObjectToCursor()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        mousePos = ray.origin;
        transform.position = mousePos;
    }
    void IsPlayerInsidePlayArea()
    {
        if (insidePlayArea == true)
        {
            sprite.material.color = new Color(0, 0, 1, 1);
            coll.isTrigger = false;
        }
        else
        {
            sprite.material.color = new Color(1, 0, 0, 1);
            coll.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "playArea")
        {
            insidePlayArea = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "playArea")
        {
            insidePlayArea = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile" && insidePlayArea == true)
        {
            Destroy(collision.gameObject);
            gameSc.score += 1;
            CatchSounds[Random.Range(0, 3)].Play();

            var particleSys = (GameObject)Instantiate(particlesStar, transform.position, Quaternion.identity);
            Destroy(particleSys, 1.0f);
        }
    }

}

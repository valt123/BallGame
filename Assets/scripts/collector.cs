using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    gameControl gameSc;
    spawn spawnSc;
    public Camera cam;
    Player playerSc;
    Vector3 BallHitPos;
    public GameObject particlesHeart;
    AudioSource Audio;

    void Start()
    {
        gameSc = GameObject.Find("GameControl").GetComponent<gameControl>();
        spawnSc = GameObject.Find("GameControl").GetComponent<spawn>();
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Audio = GetComponent<AudioSource>();
        Audio.volume = PlayerPrefs.GetFloat("AudioVolume", 0.5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            ball ballSc = collision.gameObject.GetComponent<ball>();
            BallHitPos = collision.gameObject.transform.position;
            Debug.Log(BallHitPos);

            //HealthBallCollision(ballSc.damage);

            Destroy(collision.gameObject);
            if (ballSc.damage > 0)
            {
                if (gameSc.health > 0)
                {
                    cam.backgroundColor = new Color(0.6f, 0f, 0f);
                    StartCoroutine(sleep());
                    gameSc.health -= ballSc.damage;
                    Audio.Play();
                }
            }
            else
            {
                if (gameSc.health < 100)
                {
                    gameSc.health -= ballSc.damage;
                }
            }
        }
    }

    void HealthBallCollision(float damage)
    {
        if (damage < 0)
        {
            var particleSys = (GameObject)Instantiate(particlesHeart, BallHitPos, Quaternion.identity);
            Destroy(particleSys, 1.0f);
        }
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(0.1f);
        cam.backgroundColor = new Color(0.4f,0.6f,0.9f);
    }
}

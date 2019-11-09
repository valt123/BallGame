using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject projectile;
    public float spawnRate;
    void Start()
    {
        spawnRate = 0.5f;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(spawnRate);
        Vector2 spawn = new Vector2(Random.Range(-10, 10), 10);
        Instantiate(projectile, spawn, Quaternion.identity);
        StartCoroutine(EnemySpawn());
    }
}

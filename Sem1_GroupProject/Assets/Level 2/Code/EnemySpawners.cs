using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public float min_Y = -3.5f, max_Y = 3.5f;

    public GameObject[] EnemyPlanePrefab;

    public float timer = 3f;
    void Start()
    {
        Invoke("SpawnEnemy", timer);
    }
    void SpawnEnemy()
    {
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(EnemyPlanePrefab[Random.Range(0, EnemyPlanePrefab.Length)], temp, Quaternion.identity);
        }
        Invoke("SpawnEnemy", timer);
    }

}

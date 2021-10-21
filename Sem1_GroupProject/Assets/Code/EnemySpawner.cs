using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -4.3f, max_Y = 4.3f;

    public GameObject[] Enemy_PlanePrefab;

    public float timer = 2f;
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
            Instantiate(Enemy_PlanePrefab[Random.Range(0, Enemy_PlanePrefab.Length)], temp, Quaternion.identity);
        }
        Invoke("SpawnEnemy", timer);
    }

}

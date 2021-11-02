using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3f;

    [HideInInspector]
    public bool is_EnemyBomb = false;

    void Start()
    {
        if (is_EnemyBomb)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate_Timer);

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}

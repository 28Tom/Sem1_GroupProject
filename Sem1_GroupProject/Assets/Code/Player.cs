using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float yPos;

    public GameObject PlayerBullet;
    public Transform attack_point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    void Start()
    {
        current_Attack_Timer = attack_Timer;

    }

    void Update()
    {
        MoveCharacter();
        yPos = transform.position.y;
        Attack();

    }

    void MoveCharacter()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (yPos > 3.97)
            {
                speed = 0.0f;
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                speed = 10.0f;
                transform.Translate(Vector3.up * speed * Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (yPos < -3.97)
            {
                speed = 0.0f;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                speed = 10.0f;
                transform.Translate(Vector3.down * speed * Time.deltaTime);

            }
        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(PlayerBullet, attack_point.position, Quaternion.identity);

            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlane : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotate_Speed = 50f;
    public float bound_X = -11f;
    public bool canMove = true;
    public bool canShoot;
    public bool canmove = true;
    public bool canRotate;
    public Transform AttackPoint;
    public GameObject enemyBullet;

    private Animator anim;
    private AudioSource explosionSound;

    void Awake()
    {
        anim = GetComponent < Animator> ();
        explosionSound = GetComponent<AudioSource>();
    }


    void Start()
    {
        if(canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_X)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(enemyBullet, AttackPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet")
        {
            canMove = false;

            if(canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject", 3f);

            anim.Play("Destroy");
        }
    }
}

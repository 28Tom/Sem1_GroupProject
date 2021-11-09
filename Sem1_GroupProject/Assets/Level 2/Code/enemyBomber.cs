using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomber : MonoBehaviour
{
    public float speed = 3.0f;
    public float bound_X = -11f;
    public bool canMove = true;
    public bool canShoot;
    public bool canmove = true;
    public Transform AttackPoint;
    public GameObject enemyBomb;

    private Animator anim;
    private AudioSource explosionSound;

    void Awake()
    {
        anim = GetComponent < Animator> ();
        explosionSound = GetComponent<AudioSource>();
    }


    void Start()
    {

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void Update()
    {
        Move();
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

    void StartShooting()
    {
        GameObject Bomb = Instantiate(enemyBomb, AttackPoint.position, Quaternion.identity);
        Bomb.GetComponent<Bomb>().is_EnemyBomb = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        

        if (target.tag == "Bullet")
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

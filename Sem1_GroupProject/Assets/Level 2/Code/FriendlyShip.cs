using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FriendlyShip : MonoBehaviour
{

	Rigidbody2D rb;
	float dirX, dirY;
	float moveSpeed = 5f;
	public static float healthAmount;

	void Start()
	{
		healthAmount = 1;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (healthAmount <= 0)
		{
			Destroy(gameObject);
			SceneManager.LoadScene("GameOver1");
		}
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, dirY);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("EnemyBomb(Clone)"))
			healthAmount -= 0.1f;
	}

}
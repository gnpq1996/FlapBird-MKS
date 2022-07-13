using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
	private void PlayerDeath()
	{
		EventManager.Player_died.Invoke();
		gameObject.SetActive(false);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.LogWarning("Player colidiu com: " + collision.gameObject.name);
		PlayerDeath();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		I_Point tempPoint = collision.gameObject.GetComponent<I_Point>();

		if (tempPoint != null)
		{
			ScoreManager.AddPoint(tempPoint.GetPoint());
		}
		else if (collision.gameObject.tag == "EndGame")
		{
			PlayerDeath();
		}
	}
}

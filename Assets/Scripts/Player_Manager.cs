using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.LogWarning("Player colidiu com: " + collision.gameObject.name);
		EventManager.Player_died.Invoke();
		gameObject.SetActive(false);
	}
}

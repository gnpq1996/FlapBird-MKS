using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_gravity : MonoBehaviour
{
	Rigidbody2D rb;

	[Header("Gravity")]
	[SerializeField] float up_gravity = 1;
	[SerializeField] float down_gravity = 1;
	bool canMove;

	#region MonoBehaviour
	//======================================================

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		Debug.Log("Comecando");
		canMove = false;
		rb.gravityScale = 0;
		EventManager.GameStart += EventHandler_GameStart;
	}

	private void OnDestroy()
	{
		EventManager.GameStart -= EventHandler_GameStart;
	}

	private void FixedUpdate()
	{
		if (!canMove)
		{
			return;
		}

		Jump_gravity();
	}

	#endregion

	#region Functions
	//=======================================================================

	void EventHandler_GameStart()
	{
		Debug.Log("Liberando movimento");
		canMove = true;
		rb.gravityScale = up_gravity;
	}

	private void Jump_gravity()
	{
		if (rb.velocity.y >= 0)
		{
			rb.gravityScale = up_gravity;
		}
		else
		{
			rb.gravityScale = down_gravity;
		}
	}

	#endregion
}

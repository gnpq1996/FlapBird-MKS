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

	#region MonoBehaviour
	//======================================================

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		if (rb.velocity.y >=0)
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

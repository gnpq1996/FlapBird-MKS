using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
	[Header("Jump")]
	[SerializeField] float jump_force;


	#region References
	//====================================================================

	Rigidbody2D rb;
	#endregion

	#region MonoBehaviour
	//====================================================================

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	#endregion

	#region Functions
	//====================================================================


	public void Jump()
	{
		Debug.Log(gameObject.name + " jumping");

		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * jump_force);
	}
	#endregion
}

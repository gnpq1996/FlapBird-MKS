using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrier_ : MonoBehaviour
{
	Transform[] children;

	[Header("Movement")]
	[SerializeField] float vel;
	[SerializeField] Transform x_min;

	#region MonoBehaviour
	//==============================================================

	private void Awake()
	{
		children = children = GetComponentsInChildren<Transform>();
	}

	private void FixedUpdate()
	{
		Movement();
	}

	#endregion

	#region Functions
	//==============================================================

	void Movement()
	{
		if (transform.position.x > x_min.position.x)
		{
			transform.Translate(Vector3.right * -vel * Time.deltaTime);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	public void ChangeOpening(float _newHeight)
	{
		children[1].position = new Vector3(0, -_newHeight, 0);
		children[2].position = new Vector3(0, _newHeight, 0);
	}

	#endregion
}
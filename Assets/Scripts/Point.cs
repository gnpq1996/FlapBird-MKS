using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour, I_Point
{
	[SerializeField] int value = 1;

	public int GetPoint()
	{
		return value;
	}
}

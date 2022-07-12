using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{
	[Header("References")]
    [SerializeField] GameObject barrier;
    [SerializeField] Transform y_max, y_min,x_max;

	[Header("Generation")]
    [SerializeField] List<GameObject> list_barriers = new List<GameObject>();
	[SerializeField] float interval;

	#region MonoBehaviour
	//=========================================================

	private void Awake()
	{
		//InvokeRepeating("CreateBarrier", 2, interval);
	}
	#endregion

	#region Functions
	//=========================================================


	void CreateBarrier()
	{
		float randomHeight = Random.Range(y_min.position.y, y_max.position.y);
		Vector3 randomPos = new Vector3(0, randomHeight, 0);
		GetBarrier().transform.position = randomPos;
	}

	#endregion

	#region BasicPool
	GameObject GetBarrier()
	{
		foreach (GameObject barrier in list_barriers)
		{
			if (!barrier.activeInHierarchy)
			{
				barrier.SetActive(true);
				return barrier;
			}
		}

		GameObject tempGO = Instantiate(barrier, Vector3.zero, Quaternion.identity);
		list_barriers.Add(tempGO);
		return tempGO;

	}
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{
	[Header("References")]
    [SerializeField] GameObject barrier;
	[SerializeField] Transform y_max, y_min;
	public Transform x_min;

	[Header("Generation")]
    [SerializeField] List<GameObject> list_barriers = new List<GameObject>();
	[SerializeField] float interval;
	[SerializeField] float vel;

	#region MonoBehaviour
	//=========================================================

	private void Awake()
	{
		EventManager.GameStart += EventHandler_JogoComecou;
	}

	private void OnDestroy()
	{
		EventManager.GameStart -= EventHandler_JogoComecou;
	}


	#endregion

	#region Functions
	//=========================================================
	private void EventHandler_JogoComecou()
	{
		InvokeRepeating("CreateBarrier", 2, interval);
	}

	void CreateBarrier()
	{
		float randomHeight = Random.Range(y_min.position.y, y_max.position.y);
		Vector2 randomPos = new Vector2(transform.position.x, randomHeight);
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

		//GameObject tempGO = Instantiate(barrier, transform);
		Barrier_ tempBarrier = Instantiate(barrier, transform).GetComponent<Barrier_>().Init(x_min,vel);
		tempBarrier.gameObject.SetActive(true);
		list_barriers.Add(tempBarrier.gameObject);
		return tempBarrier.gameObject;

	}
	#endregion
}

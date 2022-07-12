using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class t_DoTween : MonoBehaviour
{
	[Header("Resize")]
	[SerializeField] float resize_end;
	[SerializeField] float resize_duration;
	[SerializeField] int resize_loops;

	#region Functions
	public void ResizeY()
	{
		transform.DOScaleY(resize_end, resize_duration).SetLoops(resize_loops, LoopType.Yoyo);
	}

	public void ResizeX()
	{
		transform.DOScaleX(resize_end, resize_duration).SetLoops(resize_loops, LoopType.Yoyo);
	}
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager 
{
	public static void AddPoint(int value)
	{
		PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + value);
		EventManager.NewPoint.Invoke();
	}

	public static void Reset_score()
	{
		PlayerPrefs.SetInt("score", 0);
	}

	public static int HighScore()
	{
		PlayerPrefs.SetInt("score_high", Mathf.Max(PlayerPrefs.GetInt("score", 0), PlayerPrefs.GetInt("score_high", 0)));
		return PlayerPrefs.GetInt("score_high", 0);
	}
}

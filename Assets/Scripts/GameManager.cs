using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] GameObject UI_Jump;
	[SerializeField] GameObject UI_endGame;
	[SerializeField] float SlowDuration;

	#region MonoBehaviour
	//================================================================

	private void Awake()
	{
		EventManager.Player_died += EventHandler_PlayerDied;
	}

	private void OnDisable()
	{
		EventManager.Player_died -= EventHandler_PlayerDied;
	}

	#endregion

	#region Functions
	//================================================================

	public void btn_INVOKE_GameStart()
	{
		Debug.Log("Invoke: GameStart");
		EventManager.GameStart.Invoke();
	}
	void EventHandler_PlayerDied()
	{
		UI_Jump.SetActive(false);
		DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, SlowDuration)
			.SetEase(Ease.InQuad)
			.SetUpdate(true)
			.OnComplete(() => UI_endGame.SetActive(true));
	}

	public void ResetLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	#endregion
}

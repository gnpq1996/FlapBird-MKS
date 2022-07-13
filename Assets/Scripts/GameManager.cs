using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] GameObject UI_Jump;
	[SerializeField] GameObject UI_endGame;
	[SerializeField] float SlowDuration;

	[Header("Score")]
	[SerializeField] TextMeshProUGUI score_txt_inGame;
	[SerializeField] TextMeshProUGUI score_txt_endGame;
	[SerializeField] TextMeshProUGUI score_txt_high;


	#region MonoBehaviour
	//================================================================

	private void Awake()
	{
		Time.timeScale = 1;
		EventManager.Player_died += EventHandler_PlayerDied;
		EventManager.NewPoint += EventHandler_newPoint;

		ScoreManager.Reset_score();
	}

	private void OnDisable()
	{
		EventManager.Player_died -= EventHandler_PlayerDied;
		EventManager.NewPoint -= EventHandler_newPoint;
	}

	#endregion

	#region EventHandlers
	//================================================================

	void EventHandler_newPoint()
	{
		//Atualizar UI
		string temp = PlayerPrefs.GetInt("score", 0).ToString();
		score_txt_inGame.text = temp;
		score_txt_endGame.text = temp;
	}
	void EventHandler_PlayerDied()
	{
		//Desativar funcoes do jogo
		UI_Jump.SetActive(false);

		//Efeito de slow
		DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, SlowDuration)
			.SetEase(Ease.InQuad)
			.SetUpdate(true)
			//Ligar menu de morte so no final
			.OnComplete(() => UI_endGame.SetActive(true));

		//Atualizar UI
		score_txt_high.text = ScoreManager.HighScore().ToString();
	}

	#endregion

	#region Functions
	//================================================================

	public void btn_INVOKE_GameStart()
	{
		Debug.Log("Invoke: GameStart");
		EventManager.GameStart.Invoke();
	}


	public void ResetLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	#endregion
}

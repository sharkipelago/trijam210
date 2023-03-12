using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] TMP_Text timerText;
	[SerializeField] GameManager gameManager;
	public float timeRemainingSeconds = 60;

	public float listCompletionBonus = 20;
	void Update()
	{
		if (timeRemainingSeconds > 0)
		{
			timeRemainingSeconds -= Time.deltaTime;
			timerText.text = FormatTime(timeRemainingSeconds);
		}
		else
		{
			timerText.text = "GAME OVER";
			gameManager.OnGameOver();
		}
	}

	string FormatTime(float time)
	{
		int minutes = (int)time / 60;
		int seconds = (int)time - (minutes* 60);

		return $"{minutes} : {seconds}";
	}

	public void AddCompletionBonus()
	{
		timeRemainingSeconds += listCompletionBonus; 
	}
}

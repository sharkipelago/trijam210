using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool GameOver = false;
	public TMP_Text gameOverText;
	public int clearedRounds = 0;

	public AudioSource audioSource;
	public void OnGameOver()
	{
		GameOver = true;
		gameOverText.text = $"Game Over\r\nRounds Cleared: {clearedRounds}";
		audioSource.Play();
	}

}

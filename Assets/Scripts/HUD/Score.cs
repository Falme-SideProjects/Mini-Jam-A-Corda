using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
	private TextMeshProUGUI scoreText;

	private int score = 0;

	private void Awake()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	public void AddScore(int value)
	{
		this.score += value;
		scoreText.text = this.score.ToString();
	}


}

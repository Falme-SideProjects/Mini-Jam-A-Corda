using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
	[SerializeField] private int initialTimer = 200;
	[SerializeField] private CanvasGroup canvasGroupGameOver;

	private int currentTimer;
	private TextMeshProUGUI textTimer;

	private bool callingGameOverScreen;

    // Start is called before the first frame update
    void Awake()
    {
		currentTimer = initialTimer;
		textTimer = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		StartCoroutine(TickTimer());
	}

	private void Update()
	{
		if(callingGameOverScreen)
		{
			canvasGroupGameOver.alpha += Time.deltaTime;
			if (canvasGroupGameOver.alpha >= 1f)
			{
				canvasGroupGameOver.alpha = 1;
				callingGameOverScreen = false;
			}
		}
	}

	private IEnumerator TickTimer()
	{
		while(currentTimer > 0)
		{
			yield return new WaitForSeconds(1f);
			currentTimer--;
			textTimer.text = "Timer: " + currentTimer;
		}

		callingGameOverScreen = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private Transform buildingsTransform;
	[SerializeField] private CanvasGroup canvasGroupWinScreen;

	private bool hasWon;
	private bool finishWinScreen;

    void Update()
    {
		if(buildingsTransform.childCount <= 0)
		{
			hasWon = true;
		}
		if(hasWon && !finishWinScreen)
		{
			canvasGroupWinScreen.alpha += Time.deltaTime;
			if(canvasGroupWinScreen.alpha >= 1f)
			{
				canvasGroupWinScreen.alpha = 1f;
				finishWinScreen = true;
			}
			
		}
    }
}

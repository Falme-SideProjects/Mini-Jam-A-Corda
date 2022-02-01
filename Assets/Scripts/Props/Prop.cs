using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType
{
	Smallest,
	Small,
	Medium,
	Big,
	VeryBig,
	Huge
}

public class Prop : MonoBehaviour
{
	[SerializeField] private PropType propType;
	[SerializeField] private float velocityConsume;

	private bool isHooked = false;
	private Player player;


	public void Hook(Player player)
	{
		isHooked = true;
		this.player = player;
	}

	public void Update()
	{
		if(isHooked)
		{
			//transform.position = transform
		}
	}
}

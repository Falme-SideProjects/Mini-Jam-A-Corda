using System;
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
	Huge,
	Infinite
}

public class Prop : MonoBehaviour
{
	[SerializeField] private PropType propType;
	[SerializeField] private float velocityConsume;
	[SerializeField] private float consumeGrowth;
	[SerializeField] private int collectValue;

	[SerializeField] private GameObject[] listOfPropModels;

	private bool isHooked = false;
	private Player player;
	private BoxCollider collider;

	public static System.Random rand = new System.Random(); 

	private void Awake()
	{
		collider = GetComponent<BoxCollider>();
	}

	private void Start()
	{
		listOfPropModels[Prop.rand.Next(0, listOfPropModels.Length)].SetActive(true);
	}

	public bool Hook(Player player, PropType type)
	{
		if(type > propType)
		{
			isHooked = true;
			collider.enabled = false;
			this.player = player;
			transform.parent = this.player.transform;
			StartCoroutine(CloserToPlayer());
			return true;
		}
		return false;
	}

	private IEnumerator CloserToPlayer()
	{
		yield return null;

		while(transform.localPosition != Vector3.zero)
		{
			yield return null;
			transform.localPosition = transform.localPosition - (transform.localPosition/ velocityConsume);
		}
	}

	public float GetGrowthProgression()
	{
		return consumeGrowth;
	}

	public int GetCollectValue()
	{
		return collectValue;
	}
}

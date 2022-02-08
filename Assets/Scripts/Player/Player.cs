using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Transform fixedPivot;
	[SerializeField] private float velocityForce;

	private PropType currentType = PropType.Small;

	private int numberCollected = 0;

	private Rigidbody rigidbody;

	private bool forward, back, left, right;


    void Awake()
    {
		rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		forward = back = left = right = false;


		if (Input.GetKey(KeyCode.W))
		{
			forward = true;
		} else if(Input.GetKey(KeyCode.S))
		{
			back = true;
		}

		if (Input.GetKey(KeyCode.A))
		{
			left = true;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			right = true;
		}
	}

	private void FixedUpdate()
	{
		if(forward) rigidbody.AddForce(fixedPivot.forward * Time.fixedDeltaTime * velocityForce);
		else if(back) rigidbody.AddForce(fixedPivot.forward * -1 * Time.fixedDeltaTime * velocityForce);


		if (left) rigidbody.AddForce(fixedPivot.right * -1 * Time.fixedDeltaTime * velocityForce);
		else if (right) rigidbody.AddForce(fixedPivot.right * Time.fixedDeltaTime * velocityForce);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Prop"))
		{
			Prop prop = collision.transform.GetComponent<Prop>();
			bool consumed = prop.Hook(this, currentType);

			if (consumed)
			{
				this.transform.localScale += Vector3.one * prop.GetGrowthProgression(); // 1.1f;
				numberCollected+= prop.GetCollectValue();
				OnCollected();
			}
		}
	}

	private void OnCollected()
	{
		if (numberCollected >= 310) this.currentType = PropType.Infinite;
		else if (numberCollected >= 150) this.currentType = PropType.Huge;
		else if (numberCollected >= 70) this.currentType = PropType.VeryBig;
		else if (numberCollected >= 30) this.currentType = PropType.Big;
		else if (numberCollected >= 10) this.currentType = PropType.Medium;
	}
}

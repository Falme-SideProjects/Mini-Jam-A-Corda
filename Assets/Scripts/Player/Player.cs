using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Transform fixedPivot;
	[SerializeField] private float velocityForce;
	
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
}

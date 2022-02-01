using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField] private float velocityRotation = 1;

	void Update()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(Vector3.up*-1 * velocityRotation * Time.deltaTime, Space.Self);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			transform.Rotate(Vector3.up * velocityRotation * Time.deltaTime, Space.Self);
		}
	}
}

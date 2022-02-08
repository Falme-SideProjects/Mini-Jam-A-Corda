using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField] private float velocityRotation = 1;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Transform playerTransform;

	private Vector3 originalLocalPositionCamera;

	private void Awake()
	{
		originalLocalPositionCamera = mainCamera.transform.localPosition;
	}

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

		mainCamera.transform.localPosition = originalLocalPositionCamera + (Vector3.back* playerTransform.localScale.x) + (Vector3.up * playerTransform.localScale.y);
		//mainCamera.transform.LookAt(transform);
	}
}

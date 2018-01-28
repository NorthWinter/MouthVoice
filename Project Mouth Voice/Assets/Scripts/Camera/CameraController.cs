using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private float maxDistance;
	[SerializeField] private float speed;

	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Lerp(transform.localPosition ,new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.localPosition.z / maxDistance) * maxDistance, speed);
	}
}

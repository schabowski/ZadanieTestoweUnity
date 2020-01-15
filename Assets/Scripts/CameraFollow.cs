using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Transform pointToFollow;
	[SerializeField] private Transform playerToLookAt;

	// Use this for initialization
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = pointToFollow.position;
		transform.LookAt(playerToLookAt);
	}
}

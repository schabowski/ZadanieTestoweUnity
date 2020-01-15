using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFacer : MonoBehaviour {

	[SerializeField] private Transform playerCamera;

	void LateUpdate () {
		transform.LookAt(playerCamera);
	}
}

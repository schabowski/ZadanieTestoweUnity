using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 10f;
	[SerializeField] private float gravity = -2f;
	[SerializeField] private float jumpPower = 5f;
	[SerializeField] private float mouseXSpeed = 1f;

	private float rot = 0f;
	private float jumpMod = 0f;
	private CharacterController characterController;
	private Vector3 moveDirection;

	// Use this for initialization
	void Awake () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MovePlayer();
		RotatePlayer();
	}

	private void RotatePlayer()
	{
		rot += mouseXSpeed * Input.GetAxis("Mouse X");
		transform.eulerAngles = new Vector3(0, rot, 0);
	}

	private void MovePlayer()
	{
		moveDirection = new Vector3((Vector3.right * Input.GetAxis("Horizontal")).x, 0, (Vector3.forward * Input.GetAxis("Vertical")).z);
		if (characterController.isGrounded)
		{
			jumpMod = -1;
			if (Input.GetButtonDown("Jump")) jumpMod = jumpPower;
		}
		jumpMod += gravity * Time.deltaTime;
		moveDirection.y = jumpMod;
		moveDirection = transform.TransformDirection(moveDirection)  * speed;
		characterController.Move(moveDirection * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour {

	[SerializeField] public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))  gameManager.MoveToStart();
    }
}

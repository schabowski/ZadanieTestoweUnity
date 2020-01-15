using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private Transform startingPoint;
	[SerializeField] private Transform player;
	[SerializeField] private Interaction[] interactions;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		interactions = FindObjectsOfType<Interaction>();
		ResetGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToStart()
	{
		player.transform.position = startingPoint.position;
	}

	public void ResetGame()
	{
		MoveToStart();
		foreach (Interaction interaction in interactions)
		{
			interaction.SetStateOfRouteElements(false);
		}
	}
}

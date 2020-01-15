using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	[SerializeField] private Text textToShow;
	[SerializeField] private GameObject[] routeElements;

	private bool isPushPossible = false;
	private bool areElementsVisible = false;

	void Start()
	{
		SetStateOfRouteElements(areElementsVisible);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isPushPossible)
		{
			areElementsVisible = !areElementsVisible;
			SetStateOfRouteElements(areElementsVisible);
		}
	}

	public void SetStateOfRouteElements(bool isVisible)
	{
		foreach (GameObject routeElement in routeElements)
		{
			routeElement.SetActive(isVisible);
		}
		if (isVisible) areElementsVisible = true;
		else { areElementsVisible = false; }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			textToShow.enabled = true;
			isPushPossible = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			textToShow.enabled = false;
			isPushPossible = false;
		}
	}
}

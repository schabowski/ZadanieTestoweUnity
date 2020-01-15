using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishOperator : MonoBehaviour {

	[SerializeField] private Text finishText;
	private GameManager gameManager;
	private Interaction interaction;
	string finishTextFirstText;

	void Start()
	{
		finishText.enabled = false;
		gameManager = FindObjectOfType<GameManager>();
		interaction = FindObjectOfType<Interaction>();
		finishTextFirstText = finishText.text;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			ShowTextAndMovePlayerToStart(other.transform);
		}
	}

	private void ShowTextAndMovePlayerToStart(Transform player)
	{
		finishText.enabled = true;
		StartCoroutine(CountAndMove(3, player));
	}

	IEnumerator CountAndMove(int time, Transform player)
	{
		yield return new WaitForSeconds(3f);
		for(int i = time; i > 0; i--)
		{
			finishText.text = i.ToString();
			yield return new WaitForSeconds(1f);
		}
		finishText.enabled = false;
		finishText.text = finishTextFirstText;
		interaction.SetStateOfRouteElements(false);
		gameManager.ResetGame();
	}
}

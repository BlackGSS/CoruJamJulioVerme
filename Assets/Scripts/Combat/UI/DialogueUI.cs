using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI dialogueText;

	[SerializeField]
	private List<string> loadedTexts;

	[SerializeField]
	private bool autoInitialize = false;

	[SerializeField]
	private UnityEvent unityEventOnCompletedText;

	public Action onCompleteTexts;

	// Start is called before the first frame update
	void Start()
	{
		if (autoInitialize)
		{
			if (loadedTexts.Count > 0)
			{
				ShowDialogue(loadedTexts);
			}
		}
		else
		{
			dialogueText.gameObject.SetActive(false);
		}
	}

	public void ShowDialogue(List<string> textsToShow)
	{
		loadedTexts = new List<string>(textsToShow);
		dialogueText.text = loadedTexts[0];
		dialogueText.gameObject.SetActive(true);
		StartCoroutine(ShowTexts());
	}

	public void NextDialogue()
	{
		loadedTexts.RemoveAt(0);
		if (loadedTexts.Count > 0)
		{
			dialogueText.text = loadedTexts[0];
		}
	}

	IEnumerator ShowTexts()
	{
		while (loadedTexts.Count > 0)
		{
			yield return null;
		}

		onCompleteTexts?.Invoke();
		unityEventOnCompletedText?.Invoke();

		yield return null;
	}
}

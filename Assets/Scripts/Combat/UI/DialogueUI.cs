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
	private Button continueButton;

	[SerializeField]
	private TextScriptable textsData;

	[SerializeField]
	private bool autoInitialize = false;

	[SerializeField]
	private UnityEvent unityEventOnCompletedText;

	private List<string> loadedTexts;
	public Action onCompleteTexts;

	void Start()
	{
		if (autoInitialize)
		{
			if (textsData != null)
			{
				ShowDialogue(textsData.textsToLoad);
			}
		}
		else
		{
			dialogueText.gameObject.SetActive(false);
		}
	}

	public void ShowDialogue(List<string> textsToShow)
	{
		continueButton.gameObject.SetActive(true);
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

		continueButton.gameObject.SetActive(false);

		yield return null;
	}
}

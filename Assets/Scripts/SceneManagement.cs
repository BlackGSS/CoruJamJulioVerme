using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManagement : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup fadeImage;
	[SerializeField]
	private UnityEvent actionAfterFadeIn;

	private List<string> sceneOrder;

	private void Start()
	{
		sceneOrder = new List<string>()
		{
			"Main_menu",
			"Dialogue_01",
			"CookieClicker",
			"Combat",
			"Dialogue_02",
			"CookieClicker",
			"Combat",
			"Dialogue_03"
		};

		fadeImage.alpha = 1f;
		Sequence newSequence = DOTween.Sequence();
		newSequence.Append(fadeImage.DOFade(0f, 2f));
		newSequence.OnComplete(() =>
		{
			fadeImage.gameObject.SetActive(false);
			actionAfterFadeIn?.Invoke();
		});
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void NextScene()
	{
		fadeImage.gameObject.SetActive(true);
		fadeImage.alpha = 0f;
		Sequence newSequence = DOTween.Sequence();
		newSequence.Append(fadeImage.DOFade(1f, 2f));
		newSequence.OnComplete(() => LoadNextScene());
	}

	private void LoadNextScene()
	{
		Player.currentScene++;
		SceneManager.LoadScene(sceneOrder[Player.currentScene]);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
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

	private void Start()
	{
		fadeImage.alpha = 1f;
		Sequence newSequence = DOTween.Sequence();
		newSequence.Append(fadeImage.DOFade(0f, 2f));
		newSequence.OnComplete(() =>
		{
			fadeImage.gameObject.SetActive(false);
			actionAfterFadeIn?.Invoke();
		});
	}

	public void NextScene(string sceneName = null)
	{
		fadeImage.gameObject.SetActive(true);
		fadeImage.alpha = 0f;
		Sequence newSequence = DOTween.Sequence();
		newSequence.Append(fadeImage.DOFade(1f, 2f));
		newSequence.OnComplete(() => LoadNextScene(sceneName));
	}

	private void LoadNextScene(string sceneName)
	{
		if (sceneName != null && !string.IsNullOrEmpty(sceneName))
		{
			Player.currentScene = SceneManager.GetSceneByName(sceneName).buildIndex;
		}
		else
		{
			Player.currentScene++;
		}

		SceneManager.LoadScene(Player.currentScene);
	}
}
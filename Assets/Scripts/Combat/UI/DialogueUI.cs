using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Button buttonA;
    [SerializeField]
    private Button buttonB;

    private TextMeshProUGUI buttonAText;
    private TextMeshProUGUI buttonBText;

    public Action OnButtonAClicked;
    public Action OnButtonBClicked;

    void Awake()
    {
        buttonAText = buttonA.GetComponentInChildren<TextMeshProUGUI>();
        buttonBText = buttonB.GetComponentInChildren<TextMeshProUGUI>();
        buttonA.onClick.AddListener(OnButtonAClick);
        buttonB.onClick.AddListener(OnButtonBClick);
    }

    public void OnButtonAClick()
    {
        OnButtonAClicked?.Invoke();
    }

    public void OnButtonBClick()
    {
        OnButtonBClicked?.Invoke();
    }

    public void UpdateDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void UpdateButtonsText(List<string> buttonTexts)
    {
        buttonAText.text = buttonTexts[0];
        buttonBText.text = buttonTexts[1];
    }

    public void ShowChoiceButtons(bool active)
    {
        buttonA.gameObject.SetActive(active);
        buttonB.gameObject.SetActive(active);
    }
}

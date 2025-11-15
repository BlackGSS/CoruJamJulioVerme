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

    // Start is called before the first frame update
    void Start()
    {
        buttonAText = buttonA.GetComponentInChildren<TextMeshProUGUI>();
        buttonBText = buttonA.GetComponentInChildren<TextMeshProUGUI>();
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
}

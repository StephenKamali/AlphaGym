using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text interactText;
    [SerializeField] private GameObject minigameWindow;

    private bool isMinigameActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SubscribeToPlayer(PlayerController player)
    {
        player.OnInteractableInRange += ShowInteractText;
        player.OnInteractableOutOfRange += HideInteractText;
    }

    public void SubscribeToMinigames(Minigame[] mgames)
    {
        foreach(Minigame m in mgames)
        {
            m.MinigameStart += ShowMinigameWindow;
            m.MinigameEnd += HideMinigameWindow;
        }
    }

    private void ShowInteractText(string name)
    {
        if (!isMinigameActive)
        {
            interactText.gameObject.SetActive(true);
            interactText.text = "Press E to interact with " + name;
        }
    }

    private void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }

    private void ShowMinigameWindow()
    {
        HideInteractText();
        isMinigameActive = true;
        minigameWindow.SetActive(true);
    }

    private void HideMinigameWindow()
    {
        isMinigameActive = false;
        minigameWindow.SetActive(false);
    }
}

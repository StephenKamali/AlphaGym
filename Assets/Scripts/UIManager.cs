using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] Text interactText;

    // Start is called before the first frame update
    void Start()
    {
        player.OnInteractableInRange += ShowInteractText;
        player.OnInteractableOutOfRange += HideInteractText;
    }

    private void ShowInteractText(string name)
    {
        interactText.gameObject.SetActive(true);
        interactText.text = "Press E to interact with " + name;
    }

    private void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }
}

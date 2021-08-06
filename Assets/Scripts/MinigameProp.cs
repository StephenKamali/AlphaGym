using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameProp : MonoBehaviour, IInteractable
{
    [SerializeField] private Minigame minigame;

    public void OnInteract()
    {
        minigame.StartMinigame();
    }
}

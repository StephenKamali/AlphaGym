using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Minigame[] minigames;

    private void Start()
    {
        uiManager.SubscribeToMinigames(minigames);
        uiManager.SubscribeToPlayer(player);

        foreach (Minigame m in minigames)
        {
            Debug.Log("subscribed");
            m.MinigameStart += MinigameStarted;
            m.MinigameEnd += MinigameEnded;
        }
    }

    private void MinigameStarted()
    {
        player.Freeze();
    }

    private void MinigameEnded()
    {
        player.Unfreeze();
    }
}

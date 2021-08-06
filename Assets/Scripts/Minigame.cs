using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public event Action MinigameStart;
    public event Action MinigameEnd;

    public abstract void StartMinigame();

    protected virtual void OnMinigameStart()
    {
        MinigameStart?.Invoke();
    }
    protected virtual void OnMinigameEnd()
    {
        MinigameEnd?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> OnInputMove;
    public static event Action OnInputInteract;
    public static event Action OnInputChargeUpStart;
    public static event Action OnInputChargeUpEnd;
    private bool isChargingUp;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputValue value)
    {
        OnInputMove?.Invoke(value.Get<Vector2>());
    }

    public void OnInteract()
    {
        OnInputInteract?.Invoke();
    }

    public void OnChargeUp()
    {
        isChargingUp = !isChargingUp;

        if (isChargingUp)
            OnInputChargeUpStart?.Invoke();
        else
            OnInputChargeUpEnd?.Invoke();

    }
}

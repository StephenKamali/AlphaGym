using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : Minigame
{
    private bool isCharging;

    [SerializeField] private UnityEngine.UI.Image chargeFill;

    public override void StartMinigame()
    {
        base.OnMinigameStart();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnInputChargeUpStart += ChargeStart;
        InputManager.OnInputChargeUpEnd += ChargeEnd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCharging)
        {
            chargeFill.fillAmount += 0.5f * Time.fixedDeltaTime;
        }
    }

    private void ChargeStart()
    {
        isCharging = true;
        Debug.Log("charging start");
    }

    private void ChargeEnd()
    {
        isCharging = false;
        chargeFill.fillAmount = 0.0f;
        Debug.Log("charging end");
    }
}

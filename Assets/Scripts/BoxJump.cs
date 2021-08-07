using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : Minigame
{
    private bool isCharging;
    private bool isPlaying;

    [SerializeField] private UnityEngine.UI.Image chargeFill;

    public override void StartMinigame()
    {
        base.OnMinigameStart();
        isPlaying = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        InputManager.OnInputChargeUpStart += ChargeStart;
        InputManager.OnInputChargeUpEnd += ChargeEnd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlaying) //TODO - would be better if i could just disable this script?
        {
            if (isCharging)
            {
                chargeFill.fillAmount += 0.5f * (chargeFill.fillAmount + 1.0f + (chargeFill.fillAmount * chargeFill.fillAmount * 5.0f)) * Time.fixedDeltaTime;
            }
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

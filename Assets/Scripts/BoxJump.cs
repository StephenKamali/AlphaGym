using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxJump : Minigame
{
    private bool isCharging;
    private bool isPlaying;

    [SerializeField] private Image chargeFill;
    [SerializeField] private Text triesText;
    [SerializeField] private Text succText;
    [SerializeField] private Text failText;
    [SerializeField] private GameObject bjScene;
    [SerializeField] private BoxJumpPlayer bjPlayer;
    [SerializeField] private GameObject jumpBlock;

    private int tries = 5;
    private int successes;
    private int fails;

    public override void StartMinigame()
    {
        base.OnMinigameStart();
        bjScene.SetActive(true);
        isPlaying = true;
        Reset();
    }

    private void EndMinigame()
    {
        isPlaying = false;
        bjScene.SetActive(false);
        base.OnMinigameEnd();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnInputChargeUpStart += ChargeStart;
        InputManager.OnInputChargeUpEnd += ChargeEnd;
        bjPlayer.JumpSucceed += OnJumpSuccess;
        bjPlayer.JumpFail += OnJumpFail;
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
        if (!bjPlayer.IsJumping)
            isCharging = true;
    }

    private void ChargeEnd()
    {
        if (!bjPlayer.IsJumping)
        {
            isCharging = false;
            bjPlayer.Jump(chargeFill.fillAmount);
            chargeFill.fillAmount = 0.0f;
            triesText.text = "Tries Left - " + (--tries);
        }
    }

    private void OnJumpSuccess() //TODO - why not just consolidate Success and Fail into one event, OnJumpEnd(bool success)
    {
        if (tries != 0)
        {
            succText.text = "Successes - " + (++successes);
            bjPlayer.Reset();
            RandomizeJumpBlock();
        }
        else
        {
            EndMinigame();
        }
    }

    private void OnJumpFail()
    {
        if (tries != 0)
        {
            failText.text = "Fails - " + (++fails);
            bjPlayer.Reset();
        }
        else
        {
            EndMinigame();
        }
    }

    private void Reset()
    {
        bjPlayer.Reset();
        tries = 5;
        successes = 0;
        fails = 0;
        triesText.text = "Tries Left - " + tries;
        succText.text = "Successes - " + successes;
        failText.text = "Fails - " + fails;
        RandomizeJumpBlock();
    }

    private void RandomizeJumpBlock()
    {
        jumpBlock.transform.localScale = new Vector3(4.0f, Random.Range(1, 6) * 5.0f, 1.0f);
    }
}

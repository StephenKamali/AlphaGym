using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : Minigame
{
    public override void StartMinigame()
    {
        base.OnMinigameStart();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("begin!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpace()
    {
        Debug.Log("Charge");
    }
}

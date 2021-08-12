using System;
using System.Collections;
using UnityEngine;

public class BoxJumpPlayer : MonoBehaviour
{
    public event Action JumpSucceed;
    public event Action JumpFail;

    private Rigidbody2D rb;
    private AudioSource sound;
    public bool IsJumping { get; private set; }
    private Vector3 origPos;

    private Collision2D lastCollision;
    private bool coroutineActive;

    private void Start()
    {
        origPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float zRot = transform.rotation.eulerAngles.z;

        if (collision.gameObject.name.Equals("BJFloor") && (zRot > 2.0f && zRot < 350.0f))
        {
            sound.Play();
        }

        if (IsJumping)
        {
            lastCollision = collision;
            if (!coroutineActive) StartCoroutine("WaitForResult");
        }
    }

    public void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(jumpForce, jumpForce * 8.0f), ForceMode2D.Impulse);
        IsJumping = true;
    }

    public void Reset()
    {
        IsJumping = false;
        rb.position = origPos;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        transform.rotation = Quaternion.identity;
        
    }

    IEnumerator WaitForResult()
    {
        coroutineActive = true;

        yield return new WaitForSeconds(1.5f);

        yield return new WaitUntil(() => rb.angularVelocity == 0.0f && rb.velocity == Vector2.zero); // TODO - not sure if a good idea to wait for these values to be exactly 0

        float zRot = transform.rotation.eulerAngles.z;

        if (lastCollision.gameObject.name.Equals("Jumpblock") && (zRot <= 1.0f || zRot >= 359.0f))
        {
            JumpSucceed?.Invoke();
        }
        else
        {
            JumpFail?.Invoke();
        }

        coroutineActive = false;
    }
}

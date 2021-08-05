using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private SpriteRenderer sr;
    private Rigidbody rb;

    private Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (input.x < 0.0f)
        {
            sr.flipX = true;
        }
        else if (input.x > 0.0f)
        {
            sr.flipX = false;
        }

        rb.MovePosition(transform.position + input * Time.deltaTime * speed);
    }

    public void OnMove(InputValue value)
    {
        Vector2 vec = value.Get<Vector2>();
        input = new Vector3(vec.x, 0.0f, vec.y);
    }
}

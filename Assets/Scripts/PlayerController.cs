using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<string> OnInteractableInRange;
    public event Action OnInteractableOutOfRange;

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private SpriteRenderer sr;
    private Rigidbody rb;

    private Vector3 input;
    private List<Collider> triggersInRange;

    // Start is called before the first frame update
    void Start()
    {
        triggersInRange = new List<Collider>();

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Interactable"))
            triggersInRange.Add(other);
    }

    public void OnTriggerStay(Collider other)
    {
        if (triggersInRange.Count > 0)
        {
            foreach (Collider c in triggersInRange)
            {
                if (Vector3.Dot(other.transform.position - transform.position, sr.flipX ? transform.right : -transform.right) > 0f)
                {
                    OnInteractableInRange?.Invoke(other.name);
                    return;
                }
            }
            OnInteractableOutOfRange?.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Interactable"))
        {
            triggersInRange.Remove(other);
            if (triggersInRange.Count == 0)
                OnInteractableOutOfRange?.Invoke();
        }
    }
}

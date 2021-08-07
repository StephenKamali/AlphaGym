using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<string> OnInteractableInRange;
    public event Action OnInteractableOutOfRange;

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private SpriteRenderer sr;
    private Rigidbody rb;

    private Vector3 input;
    private List<Collider> triggersInRange;
    private Collider closestTrigger;

    private bool isFrozen;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnInputInteract += OnInteract;
        InputManager.OnInputMove += OnMove;
        triggersInRange = new List<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFrozen)
            return;

        if (input.x < 0.0f)
        {
            sr.flipX = true;
        }
        else if (input.x > 0.0f)
        {
            sr.flipX = false;
        }

        rb.MovePosition(transform.position + input * Time.deltaTime * speed);

        closestTrigger = null;

        if (triggersInRange.Count > 0)
        {
            foreach (Collider c in triggersInRange)
            {
                if (Vector3.Dot(c.transform.position - transform.position, sr.flipX ? transform.right : -transform.right) > 0f)
                {
                    OnInteractableInRange?.Invoke(c.name);
                    closestTrigger = c;
                    break;
                }
            }

            if (closestTrigger == null)
                OnInteractableOutOfRange?.Invoke();
        }
    }

    public void OnMove(Vector2 vec)
    {
        input = new Vector3(vec.x, 0.0f, vec.y);
    }

    public void OnInteract()
    {
        if (closestTrigger != null)
            closestTrigger.GetComponent<IInteractable>().OnInteract();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Interactable"))
            triggersInRange.Add(other);
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

    public void Freeze()
    {
        isFrozen = true;
    }

    public void Unfreeze()
    {
        isFrozen = false;
    }
}

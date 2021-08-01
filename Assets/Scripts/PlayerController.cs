using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    public SpriteRenderer sr;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

       /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            //rb.AddForce(-transform.right * Time.deltaTime * speed);
            rb.MovePosition(transform.position + -transform.right * Time.deltaTime * speed);
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            //rb.AddForce(transform.right * Time.deltaTime * speed);
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
            //transform.Translate(Vector3.left * Time.deltaTime * -speed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rb.AddForce(transform.forward * Time.deltaTime * speed);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //rb.AddForce(-transform.forward * Time.deltaTime * speed);
            rb.MovePosition(transform.position + -transform.forward * Time.deltaTime * speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }*/

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
}

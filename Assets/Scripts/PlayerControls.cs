using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sensitivity;
    [SerializeField] private GameObject cam;
    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        xRotation = transform.rotation.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 forceDir = Vector3.zero;

        // replace the falses with input checks for W, A, S, D
        // try to figure out for yourself which is which, note that x is left and right, and z is back and forth
        if (false)
        {
            forceDir += new Vector3((transform.forward).x, 0, (transform.forward).z);
        }
        if (false)
        {
            forceDir += new Vector3((-transform.forward).x, 0, (-transform.forward).z);
        }
        if (false)
        {
            forceDir += new Vector3((transform.right).x, 0, (transform.right).z);
        }
        if (false)
        {
            forceDir += new Vector3((-transform.right).x, 0, (-transform.right).z);
        }
        if (forceDir.magnitude < .01f)
        {
            rb.AddForce(-rb.velocity);
        }
        else
        {
            rb.AddForce(forceDir.normalized * Mathf.Max(0, (moveSpeed - rb.velocity.magnitude)));
        }
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * sensitivity);
        float unclamped = xRotation - Input.GetAxis("Mouse Y") * sensitivity;
        float newX = Mathf.Clamp(unclamped, -90f, 90f);
        xRotation = newX;
        cam.transform.localRotation = Quaternion.Euler(newX, 0, 0);
    }

}

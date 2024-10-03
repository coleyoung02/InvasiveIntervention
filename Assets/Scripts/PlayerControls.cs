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
        Vector3 moveDir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += new Vector3((transform.forward).x, 0, (transform.forward).z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += new Vector3((-transform.forward).x, 0, (-transform.forward).z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += new Vector3((transform.right ).x, 0, (transform.right).z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += new Vector3((-transform.right).x, 0, (-transform.right).z);
        }

        moveDir.y = rb.velocity.y;

        rb.velocity = moveDir * moveSpeed;

        rotate();
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * sensitivity);
        float unclamped = xRotation - Input.GetAxis("Mouse Y") * sensitivity;
        float newX = Mathf.Clamp(unclamped, -90f, 90f);
        xRotation = newX;
        cam.transform.localRotation = Quaternion.Euler(newX, 0, 0);
    }

}

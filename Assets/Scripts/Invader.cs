using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;
    private GameObject playerCam;
    private bool isDead;

    private void Start()
    {
        playerCam = FindAnyObjectByType<Camera>().gameObject;
        isDead = false;
        health = maxHealth;
    }

    private void Update()
    {
        if (!isDead)
        {
            Vector3 lookDir = transform.position - playerCam.transform.position;
            lookDir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
        else
        {

        }
    }

    private void Death()
    {
        Debug.Log("death");
        isDead = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (isDead)
        {
            return;
        }
        else if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Debug.Log("damage");
            health -= 1;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }
    }

}

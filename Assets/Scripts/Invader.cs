using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float shrinkRate;
    [SerializeField] private GameObject nameHolder;
    private float health;
    private GameObject playerCam;
    private bool isDead;
    private float scale;

    private void Start()
    {
        playerCam = FindAnyObjectByType<Camera>().gameObject;
        isDead = false;
        health = maxHealth;
        scale = 1.0f;
    }

    private void Look()
    {
        // Look at player
    }

    private void Update()
    {
        if (!isDead)
        {
            Look();
        }
        else
        {
            if (scale <= 0)
            {
                Destroy(gameObject);
            }
            scale -= shrinkRate * Time.deltaTime;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void Death()
    {
        Debug.Log("death");
        isDead = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        Flip();

        nameHolder.AddComponent<BoxCollider>();
        nameHolder.AddComponent<Rigidbody>();
    }

    private void Flip()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(UnityEngine.Random.Range(0f, 10f), UnityEngine.Random.Range(0f, 10f), UnityEngine.Random.Range(0f, 10f)), ForceMode.Impulse);
    }

    private void Damage()
    {
        Debug.Log("damage");
        health -= 1;
        scale = .5f + (.5f * health) / maxHealth;
        transform.localScale = new Vector3(scale, scale, scale);
        if (health <= 0)
        {
            health = 0;
            Death();
        }
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
            Damage();
        }
    }

}

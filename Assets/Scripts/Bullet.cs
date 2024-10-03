using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = gameObject.transform.forward * 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject gunObject;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource gunshot;
    private float zRot = 0;

    private void Shoot()
    {
        gunshot.Play();
        Debug.Log("shoot");
        zRot = -35f;
        Vector3 r = gunObject.transform.localRotation.eulerAngles;
        gunObject.transform.localRotation = Quaternion.Euler(r.x, r.y, zRot);
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunObject.transform.localRotation.z < 0)
        {
            Vector3 r = gunObject.transform.localRotation.eulerAngles;
            zRot = Mathf.Min(0, zRot + Time.deltaTime * 45);
            gunObject.transform.localRotation = Quaternion.Euler(r.x, r.y, zRot);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}

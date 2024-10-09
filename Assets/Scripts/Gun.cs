using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject gunObject;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource gunshot;
    [SerializeField] private AmmoUI ammoUi;
    [SerializeField] private int maxBullets;
    [SerializeField] private float reloadDuration;
    private int currentBullets;
    private float reloadClock = 0;
    private float zRot = 0;
    private float xRot = 0;

    private void Shoot()
    {
        currentBullets -= 1;
        gunshot.Play();
        Debug.Log("shoot");
        zRot = -35f;
        Vector3 r = gunObject.transform.localRotation.eulerAngles;
        gunObject.transform.localRotation = Quaternion.Euler(r.x, r.y, zRot);
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
        ammoUi.SetCurrentBullets(currentBullets);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
        ammoUi.SetMaxBullets(maxBullets);
        ammoUi.SetCurrentBullets(currentBullets);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = gunObject.transform.localRotation.eulerAngles;
        if (gunObject.transform.localRotation.z < 0)
        {
            zRot = Mathf.Min(0, zRot + Time.deltaTime * 45);
        }
        if (currentBullets <= 0)
        {
            zRot = 0;
            reloadClock += Time.deltaTime;
            if (reloadClock < reloadDuration / 2)
            {
                xRot += Time.deltaTime * 70 / (reloadDuration / 2);
            }
            else
            {
                xRot -= Time.deltaTime * 70 / (reloadDuration / 2);
            }
            if (reloadClock > reloadDuration)
            {
                currentBullets = maxBullets;
                xRot = 0;
                reloadClock = 0;
                ammoUi.SetCurrentBullets(currentBullets);
            }
        }
        gunObject.transform.localRotation = Quaternion.Euler(xRot, r.y, zRot);

        // check for a mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (currentBullets > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBullets = 0;
        }
    }
}

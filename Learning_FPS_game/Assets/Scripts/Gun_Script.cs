using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    private float fireRate = .15f;
    private float lastShot = -10.0f;

    public GameObject impactEffect;
    public GameObject bulletHole;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading;

    void Start()
    {
        currentAmmo = maxAmmo;
    }
    
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Time.time > fireRate + lastShot && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo --;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject bulletHoleGameObject = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bulletHoleGameObject, 2f);

        }
    }
}

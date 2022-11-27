using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    Animator gun_animator;

    public float damage = 10f;
    public float range = 100f;

    private float fireRate = .15f;
    private float lastShot = -10.0f;

    public GameObject impactEffect;
    public GameObject bulletHole;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public bool outOfAmmo = false;

    public Transform adsPosition;
    public Transform hipPosition;
    public Transform weaponAnchor;
    public GameObject retical;

    private Recoil Recoil_Script;
    public GameObject player;

    void Start()
    {
        currentAmmo = maxAmmo;

        Recoil_Script = player.transform.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();

        gun_animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            outOfAmmo = true;
            StartCoroutine(Reload());
            return;
        }

        if(Time.time > fireRate + lastShot && Input.GetKey(KeyCode.Mouse0) && !outOfAmmo)
        {
            Shoot();
            lastShot = Time.time;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            gun_animator.SetBool("isShooting", true);
        }
        else
        {
            gun_animator.SetBool("isShooting", false);
        }

        aimDownSights();
    }


    IEnumerator Reload()
    {
        isReloading = true;

        gun_animator.SetBool("isReloading", true);

        gun_animator.SetBool("isShooting", false);

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        outOfAmmo = false;

        isReloading = false;

        gun_animator.SetBool("isReloading", false);
    }

    void Shoot()
    {
        muzzleFlash.Play();

        Recoil_Script.RecoilFire();

        currentAmmo --;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (hit.transform.tag == "Target")
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject bulletHoleGameObject = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            
            Destroy(bulletHoleGameObject, 1f);


        }
    }

    void aimDownSights()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            weaponAnchor.position = Vector3.MoveTowards(weaponAnchor.position, adsPosition.position, Time.deltaTime * 3);
            retical.SetActive(false);
        }
        else
        {
            weaponAnchor.position = Vector3.MoveTowards(weaponAnchor.position, hipPosition.position, Time.deltaTime * 3);
            retical.SetActive(true);
        }
    }
}

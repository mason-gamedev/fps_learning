using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public bool isDead = false;

    public GameObject hitmarker;
    public GameObject redHitmarker;

    public AudioClip hitmarkerClip;
    public AudioClip redHitmarkerClip;
    public AudioSource audioSource;

    void Start()
    {
        hitmarker.SetActive(false);
        redHitmarker.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {

    }

    public void TakeDamage (float amount)
    {

        StartCoroutine(Hitmarker());

        health -= amount;
        if (health <= 0f)
        {
            hitmarker.SetActive(false);
            StartCoroutine(RedHitmarker());
            isDead = true;
            //Die();
            StartCoroutine(die());
        }

        IEnumerator Hitmarker()
        {
            hitmarker.SetActive(true);
            audioSource.PlayOneShot(hitmarkerClip, .7f);
            yield return new WaitForSeconds(0.2f);
            hitmarker.SetActive(false);
        }

        IEnumerator RedHitmarker()
        {
            redHitmarker.SetActive(true);
            audioSource.PlayOneShot(redHitmarkerClip, .4f);
            yield return new WaitForSeconds(0.2f);
            redHitmarker.SetActive(false);
        }

        IEnumerator die()
        {
            yield return new WaitForSeconds(0.21f);
            Destroy(gameObject);
        }
    }
}

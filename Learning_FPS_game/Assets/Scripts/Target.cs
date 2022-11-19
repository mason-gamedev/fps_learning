using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public bool isDead = false;

    public GameObject hitmarker;
    public GameObject redHitmarker;

    void Start()
    {
        hitmarker.SetActive(false);
        redHitmarker.SetActive(false);
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
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }

        IEnumerator Hitmarker()
        {
            hitmarker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hitmarker.SetActive(false);
        }

        IEnumerator RedHitmarker()
        {
            redHitmarker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            redHitmarker.SetActive(false);
        }
    }
}

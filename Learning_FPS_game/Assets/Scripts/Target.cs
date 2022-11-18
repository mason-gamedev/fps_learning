using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public bool isDead = false;

    public GameObject hitmarker;

    void Start()
    {
        hitmarker.SetActive(false);
    }

    public void TakeDamage (float amount)
    {

        //StartCoroutine(Hitmarker());

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        StartCoroutine(Hitmarker());

        void Die()
        {
            Destroy(gameObject);
            isDead = true;
        }

        IEnumerator Hitmarker()
        {
            hitmarker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hitmarker.SetActive(false);
        }
    }
}

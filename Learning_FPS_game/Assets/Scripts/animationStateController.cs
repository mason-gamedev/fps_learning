using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    Animator gun_animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gun_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("isAiming", true);
        }
        else
        {
            animator.SetBool("isAiming", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            gun_animator.SetBool("isShooting", true);
        }
        else
        {
            gun_animator.SetBool("isShooting", false);
        }
    }
}

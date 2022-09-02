using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0){
            animator.SetBool("isWalking", true);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey("left shift") && animator.GetBool("isWalking") == true){
            animator.SetBool("isSprinting", true);
        }

        if (!Input.GetKey("left shift")){
            animator.SetBool("isSprinting", false);
        }
    }
}

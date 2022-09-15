using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    private Gun_Script myGunScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myGunScript = GetComponent<Gun_Script>();
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

        if (myGunScript.isReloading == true){
            animator.SetBool("isReloading", true);
        }

        if (myGunScript.isReloading == false){
            animator.SetBool("isReloading", false);
        }

        if (Input.GetKey(KeyCode.Mouse0) == true){
            animator.SetBool("isShooting", true);

        if (Input.GetKey(KeyCode.Mouse0) == false){
            animator.SetBool("isShooting", false);
        }
        }
    }
}

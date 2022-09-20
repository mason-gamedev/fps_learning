using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_arm : MonoBehaviour
{

    public Transform weaponAnchor;
    public Transform leftHand;
    public Transform leftHandDefault;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            leftHand.position = Vector3.Lerp(leftHand.position, weaponAnchor.position, Time.deltaTime * 10);
        }
        else
        {
            leftHand.position = Vector3.Lerp(leftHand.position, leftHandDefault.position, Time.deltaTime * 10);
        }
    }
}

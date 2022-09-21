using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_arm : MonoBehaviour
{

    public Transform handGrip;
    public Transform leftHand;
    public Transform leftHandDefault;

    public Transform forearmEnd;
    public Transform forearm;
    public Transform forearmDefault;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            leftHand.position = Vector3.MoveTowards(leftHand.position, handGrip.position, Time.deltaTime * 5);
            forearm.position = Vector3.MoveTowards(forearm.position, forearmEnd.position, Time.deltaTime * 10);
        }
        else
        {
            leftHand.position = Vector3.MoveTowards(leftHand.position, leftHandDefault.position, Time.deltaTime * 5);
            forearm.position = Vector3.MoveTowards(forearm.position, forearmDefault.position, Time.deltaTime * 10);
        }
    }
}

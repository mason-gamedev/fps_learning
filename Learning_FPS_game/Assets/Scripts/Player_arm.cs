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
            //leftHand.position = Vector3.Lerp(leftHand.position, handGrip.position, Time.deltaTime * 10);
            forearm.position = Vector3.Lerp(forearm.position, forearmEnd.position, Time.deltaTime * 35);
        }
        else
        {
            //leftHand.position = Vector3.Lerp(leftHand.position, leftHandDefault.position, Time.deltaTime * 10);
            forearm.position = Vector3.Lerp(forearm.position, forearmDefault.position, Time.deltaTime * 35);
        }

        //if (Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1))
        {
            //leftHand.position = Vector3.Lerp(leftHand.position, handGrip.position, Time.deltaTime * 35);
        }
        //else
        {
            //leftHand.position = Vector3.Lerp(leftHand.position, leftHandDefault.position, Time.deltaTime * 35);

        }
    }
}

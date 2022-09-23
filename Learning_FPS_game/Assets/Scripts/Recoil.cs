using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Vector3 currentRotation;
    private Vector3 TargetRotation;

    [SerializeField] private float RecoilX;
    [SerializeField] private float RecoilY;
    [SerializeField] private float RecoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation = Vector3.Lerp(TargetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, TargetRotation, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        TargetRotation += new Vector3(RecoilX, Random.Range(-RecoilY, RecoilY), Random.Range(-RecoilZ, RecoilZ));
    }
}

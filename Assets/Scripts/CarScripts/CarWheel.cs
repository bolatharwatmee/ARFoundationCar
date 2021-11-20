using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public enum WheelType
    {
        front,
        back
    }
    [SerializeField] WheelType currentWheelType;
    WheelCollider currentWheelCollider;
    Transform wheelObject;
    Vector3 wheelCCenter;
    RaycastHit hit;

    void Start()
    {
        currentWheelCollider = GetComponent<WheelCollider>();
        wheelObject = transform.GetChild(0);
    }

    void FixedUpdate()
    {
        WheelSuspention();
    }


    public void AddMotorTorque(float _torquePower)
    {
        currentWheelCollider.brakeTorque = 0;
        currentWheelCollider.motorTorque = _torquePower;
    }
    public void AddSteering(float _steerAngel)
    {
        if (currentWheelType == WheelType.front)
            currentWheelCollider.steerAngle = _steerAngel;
    }
    public void AddBrakeTorque(float _brakePower)
    {
        currentWheelCollider.brakeTorque = _brakePower;
    }

    void WheelSuspention()
    {
        wheelObject.localEulerAngles = new Vector3(wheelObject.localEulerAngles.x, currentWheelCollider.steerAngle - wheelObject.localEulerAngles.z, wheelObject.localEulerAngles.z);
        wheelObject.Rotate(currentWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        wheelCCenter = currentWheelCollider.transform.TransformPoint(currentWheelCollider.center);

        if (Physics.Raycast(wheelCCenter, -currentWheelCollider.transform.up, out hit, currentWheelCollider.suspensionDistance + currentWheelCollider.radius))
            wheelObject.position = hit.point + (transform.up * currentWheelCollider.radius);
        else
            wheelObject.position = wheelCCenter - (transform.up * currentWheelCollider.suspensionDistance);

        wheelObject.localPosition = new Vector3(wheelObject.localPosition.x, 0, wheelObject.localPosition.z);
    }


}

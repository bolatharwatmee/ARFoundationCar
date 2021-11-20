using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCarController : MonoBehaviour
{
    [Header("Car Properties")]
    [SerializeField] int torquePower = 100;
    [SerializeField] int brakePower = 1000;
    [SerializeField] int maxSteering = 45;

    CarWheel[] carWheels;
    float x = 0;

    private void Start()
    {
        carWheels = GetComponentsInChildren<CarWheel>();
    }


    public void OnForwardButtonPress()
    {
        foreach (var carWheel in carWheels)
            carWheel.AddMotorTorque(torquePower);
    }
    public void OnBackwardButtonPress()
    {
        foreach (var carWheel in carWheels)
            carWheel.AddMotorTorque(-torquePower);
    }
    public void OnLeftButtonPress()
    {
        foreach (var carWheel in carWheels)
            carWheel.AddSteering(-maxSteering);
    }
    public void OnRightButtonPress()
    {
        foreach (var carWheel in carWheels)
            carWheel.AddSteering(maxSteering);
    }
    public void ResetAll()
    {
        foreach (var carWheel in carWheels)
        {
            carWheel.AddMotorTorque(0);
            carWheel.AddSteering(0);
        }
    }
}

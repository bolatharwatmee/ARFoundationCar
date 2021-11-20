using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCarController : MonoBehaviour
{
    [SerializeField] float powerCar = 100;
    [SerializeField] float steeringCar = 45;
    [SerializeField] Joystick joystick;
    CarWheel[] carWheels;


    private void Start()
    {
        carWheels = GetComponentsInChildren<CarWheel>();
    }

    private void FixedUpdate()
    {
        foreach (var wheel in carWheels)
        {
            wheel.AddMotorTorque(joystick.Vertical() * powerCar);
            wheel.AddSteering(joystick.Horizontal() * steeringCar);
        }
    }
}

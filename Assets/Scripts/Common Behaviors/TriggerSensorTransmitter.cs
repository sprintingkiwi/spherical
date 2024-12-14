using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSensorTransmitter : MonoBehaviour
{
    public SalioBehaviour receiver;
    public string sensor;

    void OnTriggerEnter(Collider other)
    {
        receiver.TriggerSensor(sensor, other, "Enter");
    }

    void OnTriggerExit(Collider other)
    {
        receiver.TriggerSensor(sensor, other, "Exit");
    }
}

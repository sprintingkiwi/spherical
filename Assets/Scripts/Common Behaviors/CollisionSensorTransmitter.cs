using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensorTransmitter : MonoBehaviour
{
    public GameObject receiver;
    public string sensor;

    void Start ()
    {
        if (receiver == null)
        {
            receiver = transform.parent.gameObject;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        receiver.GetComponent<Actor>().CollisionSensor(sensor, collision, "Enter");
    }

    void OnCollisionExit(Collision collision)
    {
        receiver.GetComponent<Actor>().CollisionSensor(sensor, collision, "Exit");
    }
}

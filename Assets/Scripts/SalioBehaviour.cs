using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalioBehaviour : MonoBehaviour
{
    // FUNCTION CALLED BY TRIGGER SENSORS
    public virtual void TriggerSensor(string sensor, Collider other, string type)
    {

    }

    // FUNCTION CALLED BY COLLISION SENSORS 
    public virtual void CollisionSensor(string sensor, Collision collision, string type)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveUnitRange : MonoBehaviour
{
    public bool inRange;
    public bool completingMovement;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            inRange = true;
            completingMovement = true;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            inRange = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public bool floating;
    public Vector3 startMarker;
    public Vector3 endMarker;
    public float floatSpeed = 1.0F;
    float floatStartTime;
    float floatLength;

    // Use this for initialization
    void Start ()
    {
        if (floating == true)
        {
            floatStartTime = Time.time;
            floatLength = Vector3.Distance(startMarker, endMarker);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (floating == true)
        {
            float distCovered = (Time.time - floatStartTime) * floatSpeed;
            float fracJourney = distCovered / floatLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
    }
}

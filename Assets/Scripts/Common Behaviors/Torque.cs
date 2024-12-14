using UnityEngine;
using System.Collections;

public class Torque : MonoBehaviour
{
    public Vector3 torque;
    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = torque;
	}
}

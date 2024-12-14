using UnityEngine;
using System.Collections;

public class Sand : MonoBehaviour
{
    public float force;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Actor>() != null)
        {
            Rigidbody orb = other.gameObject.GetComponent<Rigidbody>();
            orb.AddForce(rb.velocity * force);
        }
    }
}

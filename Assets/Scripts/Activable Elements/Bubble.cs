using UnityEngine;
using System.Collections;

public class Bubble : ActivableElement
{
    public Vector3 ascensionVelocity;
    Rigidbody rb;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();

        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        base.Update();        
	}

    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);

        if (other.name == player.name)
        {
            if (playerController.powerButtonDown == true)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            if (playerController.powerButton == true)
            {
                player.transform.position = transform.position;
                rb.velocity = ascensionVelocity;
            }
            if (playerController.powerButtonUp == true)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
}

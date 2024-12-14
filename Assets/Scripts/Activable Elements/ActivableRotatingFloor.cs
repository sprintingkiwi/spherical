using UnityEngine;
using System.Collections;

public class ActivableRotatingFloor : ActivableElement
{
    public Vector3 torque;
    AudioSource gearsSound;
    Rigidbody rb;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        
        gearsSound = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	public override void Update ()
    {
        base.Update();

        if (isActivable == true)
        {
            if (playerController.powerButtonDown == true)
            {
                isActive = true;
                gearsSound.Play();
            }
            if (playerController.powerButton == true)
            {
                rb.angularVelocity = torque;
                //transform.Rotate(torque);
            }
            if (playerController.powerButtonUp == true)
            {
                rb.angularVelocity = Vector3.zero;
                gearsSound.Stop();
                isActive = false;
            }
        }
	}


    public override void OnTriggerExit (Collider other)
    {
        base.OnTriggerExit(other);

        if(other.name == player.name)
        {
            rb.angularVelocity = Vector3.zero;
            gearsSound.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousElement : SalioBehaviour
{
    public GameObject player;
    public SphereController playerController;
    public bool rangedActivation;
    public bool inRange;

    // Use this for initialization
    public virtual void Start ()
    {
        player = GameObject.Find("Sphere");
        playerController = player.GetComponent<SphereController>();
    }

    // Update is called once per frame
    public virtual void Update ()
    {

	}

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnTriggerStay(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {

    }

    public virtual void OnCollisionEnter(Collision collision)
    {

    }

    public virtual void OnCollisionStay(Collision collision)
    {

    }

    public virtual void OnCollisionExit(Collision collision)
    {

    }
}

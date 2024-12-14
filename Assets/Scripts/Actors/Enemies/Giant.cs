using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : Enemy
{    
    public Animator animator;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
	}

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.name == "Sphere")
        {
            animator.SetBool("isMoving", true);
            hostile = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.gameObject.name == "Sphere")
        {
            animator.SetBool("isMoving", false);
        }
    }
}

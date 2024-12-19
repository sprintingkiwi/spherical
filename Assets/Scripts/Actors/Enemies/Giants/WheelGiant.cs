using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGiant : Giant
{

	// Use this for initialization
	public override void Start ()
    {
        base.Start();
	}

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if (inRange == true)
        {
            if (onTheFloor == true)
            {
                CheckDirection();
                rb.linearVelocity = new Vector3(targetDirection.x * speed, 0.0f, 0.0f);                                
                if (transform.position.x < target.transform.position.x)
                {
                    animator.SetFloat("movementSpeed", -speed / 35);
                }
                else
                {
                    animator.SetFloat("movementSpeed", speed / 35);
                }                
            }            
        }
	}
}

using UnityEngine;
using System.Collections;

public class LegsWorker : Worker
{
    bool targetAcquired;
    public float jumpHeight;
    bool canWalk;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();   
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if (hostile == true || isAutonomous == true)
        {
            // POINT THE TARGET AND MOVE
            if (targetAcquired == false)
            {
                Charge();
                targetAcquired = true;
            }
            if (onTheFloor == true && canWalk == true)
            {
                float jH = Random.Range(jumpHeight - 3, jumpHeight + 3);
                if (isAutonomous == false)
                {
                    targetDirection = new Vector3(targetDirection.x, 0.0f, 0.0f);
                }                
                rb.linearVelocity = (targetDirection * speed) + new Vector3(0.0f, jH, 0.0f);
            }
        }
        else
        {
            targetAcquired = false;
        }
	}

    public virtual void Charge()
    {
        CheckDirection();
        transform.rotation = Quaternion.LookRotation(Vector3.Cross(-targetDirection, Vector3.up));
        // WALK ANIMATION
        animator.SetBool("isMoving", true);
        animator.SetFloat("movementSpeed", speed / 5);
        //transform.eulerAngles = new Vector3(transform.rotation.x, Quaternion.LookRotation(target.transform.position).y, transform.rotation.z);
    }

    public override void TriggerSensor(string sensor, Collider other, string type)
    {
        base.TriggerSensor(sensor, other, type);

        if (sensor == "Legs")
        {
            if (other.GetComponent<Floor>() != null)
            {
                if (type == "Enter")
                {
                    canWalk = true;
                }
                else if (type == "Exit")
                {
                    canWalk = false;
                }
            }
        }
    }

}

using UnityEngine;
using System.Collections;

public class Enemy : Actor
{    
    public GameObject target;
    public Vector3 targetDirection;
    public Vector3 distance;
    public bool inRange;
    public bool isAutonomous;
    public Vector3 fixedDirection;
    public bool hostile;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        if (target == null)
        {
            target = GameObject.Find("Sphere");
        }
	}

    public virtual void CheckDirection()
    {
        if (isAutonomous == false)
        {
            distance = target.transform.position - transform.position;
            targetDirection = distance.normalized;            
        }
        else
        {
            targetDirection = fixedDirection;
        }
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        CheckDirection();
	}

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.name == target.name)
        {
            inRange = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.name == target.name)
        {
            inRange = false;
        }
    }
}

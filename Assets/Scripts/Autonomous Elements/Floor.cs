using UnityEngine;
using System.Collections;

public class Floor : AutonomousElement
{
    public float zLevel;
    //public bool canJump = true;    
    public float friction = 30.0f;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        player = GameObject.Find("Sphere");
        playerController = player.GetComponent<SphereController>();
        //zLevel = transform.position.z;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();   
    }

    public virtual void FixedUpdate()
    {
	
	}

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == player.name)
        {
            playerController.floorDirection = transform.right;
            //playerController.rb.velocity = playerController.rb.velocity.magnitude * playerController.direction.normalized;
            if ((playerController.rb.constraints & RigidbodyConstraints.FreezePositionZ) != RigidbodyConstraints.None)
            {
                playerController.CenterFloor(zLevel);
            }
        }
    }

    public override void OnCollisionStay(Collision collision)
    {
        //if (collision.transform.position.y > gameObject.transform.position.y)
        //{

        //}
        if (collision.gameObject.GetComponent<Actor>() != null)
        {
            Actor a = collision.gameObject.GetComponent<Actor>();
            a.onTheFloor = true;
            //a.canJump = canJump;
        }
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody orb = collision.gameObject.GetComponent<Rigidbody>();
            orb.AddForce(orb.linearVelocity.normalized * -friction);
        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Actor>() != null)
        {
            Actor a = collision.gameObject.GetComponent<Actor>();
            a.onTheFloor = false;
            //a.canJump = false;
        }            
    }
}

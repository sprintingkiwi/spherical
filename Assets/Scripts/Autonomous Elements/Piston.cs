using UnityEngine;
using System.Collections;

public class Piston : AutonomousElement
{
    public string pushAxis;
    public float startDelay;
    public float pushRate;
    public float pushSpeed;
    public float returnSpeed;
    float startTime;
    Rigidbody rb;
    enum Phase {forward, back, wait};
    Phase actualPhase;
    Vector3 startPos;
    Vector3 endPos;
    Transform pole;
    float run;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();

        startTime = -pushRate;
        rb = gameObject.GetComponent<Rigidbody>();        
        startPos = transform.position;
        pole = transform.Find("Pole");
        run = (pole.localScale.y * 2);
        actualPhase = Phase.wait;

        if (pushAxis == "x")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        else if (pushAxis == "y")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        else if (pushAxis == "z")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if (Time.timeSinceLevelLoad > startDelay)
        {
            if (actualPhase == Phase.wait && Time.time - startTime >= pushRate)
            {
                startPos = transform.position;
                actualPhase = Phase.forward;
            }

            if (actualPhase == Phase.forward)
            {
                if ((transform.position - startPos).magnitude < run)
                {
                    rb.velocity = -transform.forward * pushSpeed;
                }
                else
                {
                    endPos = transform.position;
                    actualPhase = Phase.back;
                }
            }
            else if (actualPhase == Phase.back)
            {
                if ((transform.position - endPos).magnitude < run)
                {
                    rb.velocity = transform.forward * returnSpeed;
                }
                else
                {
                    rb.velocity = Vector3.zero;
                    startTime = Time.time;
                    actualPhase = Phase.wait;
                }
            }
        }
    }


    public override void OnTriggerEnter (Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.isTrigger == false)
        {
            if (other.gameObject.name == player.name)
            {
                playerController.rb.constraints = RigidbodyConstraints.FreezePositionX;
            }
        }
    }


    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);

        if (other.isTrigger == false)
        {
            if (actualPhase == Phase.back)
            {
                if (other.GetComponent<Actor>() != null)
                {
                    Actor a = other.GetComponent<Actor>();
                    a.Explode(gameObject);
                }
            }
        }
    }
}

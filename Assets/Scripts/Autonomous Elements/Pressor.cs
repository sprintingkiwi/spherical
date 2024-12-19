using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressor : AutonomousElement
{
    Rigidbody rb;
    public float upSpeed;
    public float downForce;
    Vector3 startPos;
    Vector3 endPos;
    public float delay;
    float startPause;
    public float pauseOnFloor;
    bool fallen;
    ParticleSystem shockwave;
    ParticleSystem dust;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        fallen = false;
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = transform.position;
        shockwave = transform.Find("Shockwave").GetComponent<ParticleSystem>();
        dust = transform.Find("Dust").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if (fallen == false)
        {
            rb.AddForce(Vector3.down * downForce);
        }

        if (fallen == true)
        {
            if (Time.timeSinceLevelLoad > delay)
            {
                if (Time.time - startPause > pauseOnFloor)
                {
                    if ((transform.position - endPos).magnitude < (startPos - endPos).magnitude)
                    {
                        rb.linearVelocity = Vector3.up * upSpeed;
                    }
                    else
                    {
                        fallen = false;
                    }
                }
            }
        }
	}


    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<Floor>() != null)
        {
            shockwave.Play();
            dust.Play();
            endPos = transform.position;
            startPause = Time.time;
            fallen = true;
        }
    }


    void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.GetComponent<Floor>() != null)
        {
            rb.AddForce(Vector3.down * downForce);
        }        
    }


    void OnTriggerStay (Collider other)
    {
        if (other.isTrigger == false)
        {
            if (other.gameObject.GetComponent<Actor>() != null)
            {
                Actor a = other.gameObject.GetComponent<Actor>();
                if (a.onTheFloor == true)
                {
                    a.Explode(gameObject);
                }
            }
        }        
    }
}

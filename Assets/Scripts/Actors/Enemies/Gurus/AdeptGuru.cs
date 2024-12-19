using UnityEngine;
using System.Collections;

public class AdeptGuru : Guru
{
    public Vector3 rotationAxis;
    public float minDistance;
    public bool follower;
    public bool orbitAround;
    public bool patrol;
    bool tooFar;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (hostile == true)
        {
            if ((transform.position - target.transform.position).magnitude > minDistance * 10)
            {
                tooFar = true;
            }
            if ((transform.position - target.transform.position).magnitude < (minDistance - 1))
            {
                rb.linearVelocity = targetDirection * -speed * 2;
            }

            if (tooFar == false)
            {
                if (follower == true)
                {
                    // MOVEMENT TOWARD PLAYER        
                    if (distance.magnitude > minDistance)
                    {
                        //rb.AddForce(distance.normalized * speed);
                        rb.linearVelocity = targetDirection * speed;
                    }
                    else
                    {
                        rb.linearVelocity = new Vector3(0, 0, 0);
                    }
                }

                if (orbitAround == true)
                {
                    // ORBIT AROUND TARGET
                    transform.RotateAround(target.transform.position, rotationAxis, speed * Time.deltaTime);
                }
            }
            else
            {
                if (distance.magnitude > minDistance * 2)
                {
                    //rb.AddForce(distance.normalized * speed);
                    rb.linearVelocity = targetDirection * speed * 5;
                }
                else
                {
                    tooFar = false;
                }
            }
        }        
    }

    public override void TriggerSensor(string sensor, Collider other, string type)
    {
        base.TriggerSensor(sensor, other, type);

        if (sensor == "Hostility")
        {
            if (other.gameObject.name == target.name && other.isTrigger == false)
            {
                if (type == "Enter")
                {
                    hostile = true;
                }
            }            
        }
    }
}

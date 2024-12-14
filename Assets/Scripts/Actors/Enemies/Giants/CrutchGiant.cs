using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrutchGiant : Giant
{
    Actor rLeg;
    public bool poking;
    float pokeTime;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        //rLeg = FindDeepChild(transform, "RLeg").gameObject.GetComponent<Actor>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (inRange == true)
        {
            
            if (onTheFloor == true)
            {
                //poking = false;
                pokeTime = Time.time;
                if (transform.position.x < target.transform.position.x)
                {
                    animator.SetFloat("movementSpeed", -1);
                }
                else
                {
                    animator.SetFloat("movementSpeed", 1);
                }
            }
            else
            {
                if (Time.time - pokeTime < 1)
                {
                    rb.AddForce(targetDirection * speed);
                    //poking = true;
                }
            }
            //if (rLeg.onTheFloor == true)
            //{
            //    Debug.Log("la gamba tocca!");
            //}
        }
    }

    public override void TriggerSensor(string sensor, Collider other, string type)
    {
        base.TriggerSensor(sensor, other, type);

        if (sensor == "Pressor Base")
        {
            if (other.GetComponent<Actor>() != null && other.isTrigger == false)
            {
                if (type == "Enter")
                {
                    Actor a = other.GetComponent<Actor>();
                    a.Explode(gameObject);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guru : Enemy
{
    public float leadershipRange;
    SphereCollider sc;
    public float shootLastTime;
    public float shootDeltaTime;
    public float fireRate;
    public GameObject bullet;
    public bool shooter;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        sc = gameObject.GetComponent<SphereCollider>();
        sc.radius = leadershipRange;

        if (shooter == true)
        {
            // FIND TARGET
            target = GameObject.Find("Sphere");
        }
        
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if (hostile == true)
        {
            if (shooter == true)
            {
                // SHOOT
                shootDeltaTime = Time.time - shootLastTime;
                if (shootDeltaTime >= fireRate)
                {
                    shootLastTime = Time.time;
                    Bullet b = (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>();
                    b.owner = gameObject;
                    b.GetComponent<Rigidbody>().velocity = targetDirection * b.speed;
                    Destroy(b.gameObject, b.lifeTime);
                }
            }
        }        
    }

    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.GetComponent<Worker>() != null)
        {
            other.GetComponent<Worker>().hostile = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.GetComponent<Worker>() != null)
        {
            other.GetComponent<Worker>().hostile = true;
        }
    }
}

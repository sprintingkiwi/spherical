using UnityEngine;
using System.Collections;

public class Follower : Enemy
{
    public float minDistance;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        // MOVEMENT TOWARD PLAYER        
        if (distance.magnitude > minDistance)
        {
            //rb.AddForce(distance.normalized * speed);
            rb.velocity = distance.normalized * speed;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }        
    }
}

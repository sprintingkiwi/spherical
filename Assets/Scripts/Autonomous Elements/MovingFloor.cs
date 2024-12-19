using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : Floor
{
    public Rigidbody rb;
    public float speed;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 deltaMovement;
    public Vector3 direction;
    public bool movesOnZAxis;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        rb = gameObject.GetComponent<Rigidbody>();

        startPos = transform.position;
        if (deltaMovement != Vector3.zero)
        {
            endPos = startPos + deltaMovement;
        }        
        direction = endPos - startPos;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        BackAndForth();
    }    

    public virtual void BackAndForth()
    {
        rb.linearVelocity = direction.normalized * speed;
        if ((transform.position - startPos).magnitude >= direction.magnitude)
        {
            speed = speed * -1;
            startPos = transform.position;
        }
    }
}


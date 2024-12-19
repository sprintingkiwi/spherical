using UnityEngine;
using System.Collections;

public class MovingPusher : GravityHook
{
    Rigidbody rb;
    public float speed;
    Vector3 startPos;
    Vector3 actualPos;
    public Vector3 endPos;
    Vector3 direction;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = transform.position;
        direction = endPos - startPos;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        rb.linearVelocity = direction.normalized * speed;
        actualPos = transform.position;
        if ((actualPos - startPos).magnitude > direction.magnitude)
        {
            speed = speed * -1;
            startPos = transform.position;
        }
    }
}

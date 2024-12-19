using UnityEngine;
using System.Collections;

public class LinePatrol : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 actualPos;
    public Vector3 endPos;
    public Vector3 direction;
    public Rigidbody rb;
    public float speed;

    // Use this for initialization
    public virtual void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = transform.position;
        direction = endPos - startPos;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        rb.linearVelocity = direction.normalized * speed;
        actualPos = transform.position;
        if ((actualPos - startPos).magnitude > direction.magnitude)
        {
            speed = speed * -1;
            startPos = transform.position;
        }
    }
}

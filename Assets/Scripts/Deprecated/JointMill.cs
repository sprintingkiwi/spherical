using UnityEngine;
using System.Collections;

public class JointMill : ActivableElement
{
    public Vector3 rotationForce;    
    GameObject pivot;
    GameObject blade;
    Vector3 bladeJoint;
    float startTime;
    public float deltaTime;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        pivot = transform.Find("Pivot").gameObject;
        startTime = Time.time;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        foreach (Transform child in transform)
        {
            if (child.tag == "Mill Blade")
            {
                child.GetComponent<Rigidbody>().AddRelativeForce(rotationForce);
            }
        }

        if (Time.time - startTime > deltaTime)
        {
            rotationForce *= -1;
            startTime = Time.time;
        }
    }
}

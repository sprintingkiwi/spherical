using UnityEngine;
using System.Collections;

public class OrbitAround : Enemy
{
    public Vector3 rotationAxis;  

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();        

        // ORBIT AROUND TARGET
        transform.RotateAround(target.transform.position, rotationAxis, speed * Time.deltaTime);
    }
}

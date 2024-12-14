using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Enemy
{
    public Animator animator;
    public bool selfDestruction;
    public float selfDestructionTimer;
    public float startDestructTime;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        animator = gameObject.GetComponentInChildren<Animator>();
        if (isAutonomous == true)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(-fixedDirection, Vector3.up));
        }
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        // SELF DESTRUCTION
        if (rb.velocity.magnitude < 0.1 && selfDestruction == false)
        {
            startDestructTime = Time.time;
            selfDestruction = true;
        }
        if (Time.time - startDestructTime > selfDestructionTimer && selfDestruction == true)
        {
            if (rb.velocity.magnitude < 0.1)
            {
                Explode(gameObject);
            }                
        }
    }
}

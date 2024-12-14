using UnityEngine;
using System.Collections;

public class PulsingElement : AutonomousElement
{
    public Vector3 deltaScale;
    public float pulseRange;
    Vector3 startScale;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        startScale = transform.localScale;
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        if ((startScale - transform.localScale).magnitude < pulseRange)
        {
            transform.localScale += deltaScale;
        }
        else
        {
            deltaScale *= -1;
            startScale = transform.localScale;
        }
    }
}

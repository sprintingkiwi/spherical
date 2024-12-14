using UnityEngine;
using System.Collections;

public class BouncingBall : Actor
{
	// Use this for initialization
	public override void Start ()
    {
        base.Start();
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (transform.position.y > 300)
        {
            rb.velocity = new Vector3(Random.Range(-30, 30), -200, Random.Range(-30, 30));
        }
    }
}

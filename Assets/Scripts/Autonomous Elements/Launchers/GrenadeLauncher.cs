using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Launcher
{
    public float timer;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();

        unit.GetComponent<Grenade>().timer = timer;
	}

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();        
    }

    public override void Shoot()
    {
        // SHOOT
        shootDeltaTime = Time.time - shootLastTime;
        if (shootDeltaTime >= fireRate)
        {
            shootLastTime = Time.time;
            for (int i = 0; i < unitsPerShot; i++)
            {
                Vector3 starDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                GameObject s = Instantiate(unit, transform.position, transform.rotation, transform) as GameObject;
                s.GetComponent<Grenade>().timer = timer;
                s.GetComponent<Rigidbody>().AddForce(starDirection * startSpeed);
                Destroy(s, lifeTime);
            }
        }
    }
}

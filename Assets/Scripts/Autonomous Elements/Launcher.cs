using UnityEngine;
using System.Collections;

public class Launcher : AutonomousElement
{       
    public float shootLastTime;
    public float shootDeltaTime;
    public float fireRate;
    public GameObject unit;
    public int unitsPerShot;
    public float lifeTime;
    public float startSpeed;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        Shoot();
    }

    // SHOOT
    public virtual void Shoot ()
    {
        shootDeltaTime = Time.time - shootLastTime;
        if (shootDeltaTime >= fireRate)
        {
            shootLastTime = Time.time;
            for (int i = 0; i < unitsPerShot; i++)
            {
                Vector3 starDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                GameObject s = Instantiate(unit, transform.position, transform.rotation, transform) as GameObject;
                s.GetComponent<Rigidbody>().AddForce(starDirection * startSpeed);
                Destroy(s, lifeTime);
            }
        }
    }
}

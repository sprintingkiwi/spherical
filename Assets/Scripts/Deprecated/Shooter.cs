using UnityEngine;
using System.Collections;

public class Shooter : Enemy
{       
    public float shootLastTime;
    public float shootDeltaTime;
    public float fireRate;
    public GameObject bullet;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        // FIND TARGET
        target = GameObject.Find("Sphere");
    }
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();        

        // SHOOT
        shootDeltaTime = Time.time - shootLastTime;
        if (shootDeltaTime >= fireRate)
        {
            shootLastTime = Time.time;
            Bullet b = (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>();
            b.owner = gameObject;
            b.GetComponent<Rigidbody>().velocity = distance.normalized * b.speed;
            Destroy(b.gameObject, b.lifeTime);
        }
    }
}

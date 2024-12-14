using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GravityHook : ActivableElement
{    
    public float attractionForce;
    public int gType;    
    public SphereCollider hookCollider;
    public Light hookLight;
    public Object[] actors;
    ParticleSystem flyingKindle;
    public float lifeTime;
    public float polarity;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        rend = gameObject.GetComponent<Renderer>();

        // FIND ALL ACTORS
        actors = GameObject.FindObjectsOfType(typeof(Actor));

        //INIT HOOK COLLIDERS
        hookCollider = gameObject.GetComponent<SphereCollider>();
        hookCollider.radius = (gRadius / transform.localScale.x);

        //INIT HOOK LIGHTS
        GameObject lightchild = transform.Find("light").gameObject;
        hookLight = lightchild.GetComponent<Light>();
        hookLight.range = 0;

        // PARTICLES
        flyingKindle = transform.Find("Flying Kindle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (isActivable == true)
        {
            if (playerController.powerButtonDown == true)
            {
                isActive = true;
                gameObject.GetComponent<AudioSource>().Play();
            }
            if (playerController.powerButton == true)
            {
                playerController.rb.AddExplosionForce((attractionForce * polarity), transform.position, gRadius);
            }
            if (playerController.powerButtonUp == true)
            {
                isActive = false;
            }
        }
    }


    public override void OnTriggerEnter (Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.name == player.name)
        {
            // LIGHT
            hookLight.range = gRadius;
            // PARTICLE
            if (flyingKindle.isPlaying == false)
            {
                flyingKindle.Play();
            }            
        }        
    }


    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.name == player.name)
        {
            // LIGHT
            hookLight.range = 0;
            // PARTICLE
            if (flyingKindle.isPlaying == true)
            {
                flyingKindle.Stop();
            }
        }        
    }
}

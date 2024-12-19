using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MagneticRope : ActivableElement
{    
    public float attractionForce;
    public int gType;    
    public SphereCollider hookCollider;
    public Light hookLight;
    public float lifeTime;
    public float polarity;
    AudioSource gearsSound;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        rend = gameObject.GetComponent<Renderer>();
        gearsSound = gameObject.GetComponent<AudioSource>();

        //INIT HOOK COLLIDERS
        hookCollider = gameObject.GetComponent<SphereCollider>();
        hookCollider.radius = (gRadius / transform.localScale.x);

        //INIT HOOK LIGHTS
        GameObject lightchild = transform.Find("light").gameObject;
        hookLight = lightchild.GetComponent<Light>();
        hookLight.range = 0;      
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (isActivable == true)
        {
            if (playerController.powerButtonDown == true && playerController.usingPower == false)
            {
                isActive = true;
                gearsSound.Play();
                playerController.usingPower = true;
            }
            if (playerController.powerButton == true && isActive == true)
            {                
                transform.Find("Tracker").position = player.transform.position;
                playerController.rb.linearVelocity = Vector3.zero;
                player.transform.RotateAround(transform.position, transform.forward, attractionForce / 2 * Time.deltaTime * polarity);
                transform.Find("Rope").LookAt(player.transform);
            }
            else if (playerController.powerButtonUp == true && isActive == true)
            {
                transform.Find("Tracker").position = transform.position;
                Vector3 direction = Vector3.Cross((player.transform.position - transform.position).normalized, transform.forward);
                Vector3 playerDistance = player.transform.position - transform.position;
                //playerController.rb.AddForce(direction * attractionForce * -polarity * (playerDistance.magnitude) * 1.5f);
                playerController.rb.AddForce(direction * attractionForce * -polarity * 10);
                isActive = false;
                playerController.usingPower = false;
            }
        }
    }

    public override void LateUpdate()
    {
        base.LateUpdate();

        if (isActive == false)
        {
            transform.Rotate(transform.forward, attractionForce / 30 * polarity);
        }
    }


    public override void OnTriggerEnter (Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.name == player.name)
        {            
            // LIGHT
            hookLight.range = gRadius;          
        }        
    }


    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.name == player.name)
        {
            // LIGHT
            hookLight.range = 0;
        }        
    }
}

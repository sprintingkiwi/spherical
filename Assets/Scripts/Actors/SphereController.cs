using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
//using XInputDotNetPure;

public class SphereController : Actor
{
    // MOVEMENT
    public float horizontal;
    //public float friction;
    public float autoAcceleration;    
    Vector3 movement;
    float tiltSensibility = 1f;
    public bool powerButton;
    public bool powerButtonDown;
    public bool powerButtonUp;
    public bool jumpButtonDown;
    //public GameObject powerTouchButton;
    public Vector3 movementDirection;
    public float maxSpeed;
    public float maxTorqueSpeed;
    public float jump;
    public float pressureOnFloor;    
    // ACTIVABLE ELEMENTS LIST
    public List<GameObject> activableElements = new List<GameObject>();
    // OTHER ATTRIBUTES
    public GameObject sounds;
    // GAMEPAD VIBRATION
    //public float vibrationThreshold;
    //public float[] vibrationPower;
    // BREATH
    Vector3 breathStartScale;
    public Vector3 breathDeltaScale;
    public float breathSpeed;
    GameObject explosion;
    public bool usingPower;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        startTime = Time.time;
        gameObject.GetComponent<TrailRenderer>().autodestruct = false;
        sounds = transform.Find("Sounds").gameObject;
        breathStartScale = transform.localScale;
        rb.maxAngularVelocity = maxTorqueSpeed;
        collisionNormal = Vector3.zero;
        explosion = transform.Find("Explosion").gameObject;
    }

    // Update is called once per frame
    public override void LateUpdate()
    {
        base.LateUpdate();

        // UPDATE ATTRIBUTES EVERY FRAME
        velocityMagnitude = rb.velocity.magnitude;

        // ANDROID CONTROL        
        if (Application.platform == RuntimePlatform.Android)
        {            
            // HORIZONTAL INPUT
            horizontal = Input.acceleration.x;
            tiltSensibility = 5;

            //// POWER TOUCH BUTTON
            //powerTouchButton.SetActive(true);
            //Button ptb = powerTouchButton.GetComponent<Button>();
            //ptb.onClick.AddListener(PowerTouchButton);
        }
        else
        // GAMEPAD or KEYBOARD CONTROL
        {
            horizontal = Input.GetAxis("Horizontal");

            // JUMP BUTTOn
            if (Input.GetButtonDown("Jump") == true)
            {
                jumpButtonDown = true;
            }
            else
            {
                jumpButtonDown = false;
            }

            // PERSISTENT POWER BUTTON PRESSION
            if (Input.GetButton("Main Trigger") == true)
            {
                powerButton = true;
                //ActivatePowers();
            }
            else
            {
                powerButton = false;
                //DeactivatePowers();
            }

            // SINGLE POWER BUTTON PRESSION
            if (Input.GetButtonDown("Main Trigger") == true)
            {
                powerButtonDown = true;
            }
            else
            {
                powerButtonDown = false;
            }

            // POWER BUTTON RELEASE
            if (Input.GetButtonUp("Main Trigger") == true)
            {
                powerButtonUp = true;
            }
            else
            {
                powerButtonUp = false;
            }
        }

        ApplyMovement();

        // DEBUG GUI LOG
        //Log("Speed: " + velocityMagnitude.ToString("F0"));
        //Log(horizontal.ToString());
        //Log("Persistent: " + powerButton + "; Down: " + powerButtonDown + "; Up: " + powerButtonUp);
        
        // WALKING or FLYING
        if (onTheFloor == false)
        {

        }
        else
        {
            rb.AddForce(rb.velocity.normalized * autoAcceleration);
        }

        Breath(breathSpeed);
    }

    // JUMP
    void Jump()
    {
        rb.AddForce(Vector3.up * jump/2);
        rb.AddForce(Vector3.Cross(floorDirection.normalized, Vector3.forward) * -jump/2);
        sounds.transform.Find("Jump").gameObject.GetComponent<AudioSource>().Play();
    }

    // MOVEMENT
    void ApplyMovement ()
    {
        //movementDirection = floorDirection;
        movementDirection = Vector3.Cross(collisionNormal, Vector3.forward).normalized;

        rb.AddTorque(Vector3.back * speed * horizontal * Time.deltaTime * 50);
        //rb.angularVelocity = Vector3.back * speed * horizontal * Time.deltaTime * 50;
        if (onTheFloor == true && maxSpeed > velocityMagnitude)
        {
            // find direction
            //movement = Vector3.right * horizontal;
            movement = movementDirection * horizontal;

            // velocity lerp movement
            //rb.velocity = movement * speed * tiltSensibility * Time.deltaTime * 10;

            // addforce movement           
            rb.AddForce(movement * speed * tiltSensibility * Time.deltaTime * 100);

            // pressure on floor experiment
            //rb.AddForce(Vector3.Cross(direction.normalized, Vector3.forward) * pressureOnFloor);
        }
        if (jumpButtonDown == true && onTheFloor == true)
        {
            Jump();
        }
    }

    // BREATH
    void Breath (float breathSpeed)
    {
        transform.localScale = breathStartScale + (breathDeltaScale * Mathf.PingPong((Time.time * breathSpeed), 1));
    }


    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }


    public override void OnCollisionStay(Collision collision)
    {
        base.OnCollisionStay(collision);

        collisionNormal = Vector3.zero;
        foreach (ContactPoint contact in collision.contacts)
        {
            collisionNormal += contact.normal;
        }
    }


    public override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);

        collisionNormal = Vector3.zero;
    }

    public override void Explode(GameObject responsible)
    {
        Debug.Log(gameObject.name + " exploded!");
        explosion.transform.parent = GameObject.Find("Garbage Collector").transform;
        explosion.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        //GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //Destroy(gameObject);
        GameObject.Find("Game Controller").GetComponent<GameController>().playerIsDead = true;
    }

    public void Resurrect()
    {
        Debug.Log(gameObject.name + " resurrected!");        
        explosion.transform.parent = transform;
        explosion.transform.position = transform.position;
        explosion.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        //GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        //Destroy(gameObject);
        GameObject.Find("Game Controller").GetComponent<GameController>().playerIsDead = false;        
    }

    //// TouchScreen POWER BUTTON BEHAVIOR
    //void PowerTouchButton()
    //{
    //    powerButton = true;
    //}
}
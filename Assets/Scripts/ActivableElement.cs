using UnityEngine;
using System.Collections;

public class ActivableElement : SalioBehaviour
{
    public Renderer rend;
    public bool isActive;
    public bool isActivable;
    public bool onTheFloor;
    public float gRadius;
    public GameObject player;
    public SphereController playerController;

    // Use this for initialization
    public virtual void Start ()
    {
        player = GameObject.Find("Sphere");
        playerController = player.GetComponent<SphereController>();
    }
	
	// Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }


    public virtual void OnTriggerStay (Collider other)
    {

    }


    public virtual void OnTriggerEnter (Collider other)
    {
        if (other.name == player.name)
        {
            isActivable = true;
            // ADD THIS GRAVITY HOOK TO SPHERE'S ACTIVABLE POWERS LIST
            other.gameObject.GetComponent<SphereController>().activableElements.Add(gameObject);
        }            
    }


    public virtual void OnTriggerExit (Collider other)
    {
        if (other.name == player.name)
        {
            isActivable = false;
            // REMOVE THIS GRAVITY HOOK TO SPHERE'S ACTIVABLE POWERS LIST
            other.gameObject.GetComponent<SphereController>().activableElements.Remove(gameObject);
        }            
    }
}

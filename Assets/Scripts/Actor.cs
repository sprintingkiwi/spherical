using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// CLASS FOR COMMON ATTRIBUTES AND BEHAVIORS OF ALL ACTORS
public class Actor : SalioBehaviour
{
    //public bool undergoGravity;
    // TEXT FOR GUI LOG
    public GameObject logObject;
    // COMMON COMPONENTS
    public Rigidbody rb;
    public Rigidbody childRb;
    public Renderer rend;
    // SPEED
    public float speed;
    public float velocityMagnitude;
    // DIRECTION OF THE FLOOR YOU ARE TOUCHING
    public Vector3 floorDirection;
    // NORMAL TO THE COLLISION USEFUL TO KNOW THE MOVEMENT DIRECTION
    public Vector3 collisionNormal;
    // INSTANTIATED OBJECTS    
    //public GameObject projectile;
    // COUNTER
    public float startTime;
    public float deltaTime;
    // OTHER ATTRIBUTES
    public bool onTheFloor;
    //public bool canJump;

    // Use this for initialization
    public virtual void Start ()
    {
        // INIT COMMON COMPONENTS
        if (childRb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        else
        {
            rb = childRb;
        }
        
        rend = gameObject.GetComponent<Renderer>();
        floorDirection = Vector3.right;
        //rend.material = materials[0];
        
        // LOAD PREFAB RESOURCES
        //projectile = (GameObject)Resources.Load("prefabs/Projectile", typeof(GameObject));
    }

    public void Log(string newText)
    {
        logObject.GetComponent<Text>().text = newText;
    }

    // HOW TO FIND THE CLOSEST ACTOR
    public Actor GetClosestEnemy(Actor[] enemies)
    {
        Actor tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Actor t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    // RECURSIVE FIND CHILD
    public static Transform FindDeepChild(Transform aParent, string aName)
    {
        var result = aParent.Find(aName);
        if (result != null)
        {
            return result;
        }
        else
        {
            foreach (Transform child in aParent)
            {
                FindDeepChild(child, aName);                    
            }
        }
        return null;           
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public virtual void OnCollisionEnter (Collision collision)
    {
        //if (collision.gameObject.GetComponent<Actor>() != null)
        //{
        //    collision.gameObject.GetComponent<Actor>().onTheFloor = true;
        //}
    }

    public virtual void OnCollisionStay (Collision collision)
    {

    }

    public virtual void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Actor>() != null)
        //{
        //    collision.gameObject.GetComponent<Actor>().onTheFloor = false;
        //}
    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnTriggerStay(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {

    }    

    public virtual void Explode (GameObject responsible)
    {
        Debug.Log(gameObject.name + " exploded!" + " - responsible: " + responsible.name);
        GameObject explosion = transform.Find("Explosion").gameObject;
        explosion.transform.parent = GameObject.Find("Garbage Collector").transform;
        explosion.SetActive(true);
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);
    }

    public virtual void CenterFloor(float zLevel)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, zLevel);
    }
}

using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour
{
    public float timer;
    float startTime;
    GameObject explosion;

	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
        explosion = transform.Find("Explosion").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.time - startTime > timer)
        {
            explosion.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 10);
        }
	}


    void OnTriggerEnter (Collider other)
    {
        if (other.isTrigger == false)
        {
            if (explosion.activeSelf == true)
            {
                if (other.gameObject.GetComponent<Actor>() != null)
                {
                    Actor a = other.gameObject.GetComponent<Actor>();
                }
            }
            
        }
        
    }
}

using UnityEngine;
using System.Collections;

public class GameBox : MonoBehaviour
{
    public Vector3 gameDirection;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}


    void OnTriggerStay (Collider other)
    {
        // SET CORRECT PARAMETERS FOR ALL ACTORS
        if (other.gameObject.GetComponent<Actor>() != null)
        {
            Actor a = other.gameObject.GetComponent<Actor>();
            a.floorDirection = gameDirection;
        }
    }
}

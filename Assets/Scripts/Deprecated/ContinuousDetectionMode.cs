using UnityEngine;
using System.Collections;

public class ContinuousDetectionMode : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

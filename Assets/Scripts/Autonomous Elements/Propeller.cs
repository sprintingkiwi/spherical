using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float speed;
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("propellerSpeed", speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

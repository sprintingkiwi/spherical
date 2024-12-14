using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    AudioSource effect;

    // Start is called before the first frame update
    void Start()
    {
        effect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere")
        {
            effect.Play();
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.name == "Sphere")
    //    {

    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public bool repeat;
    AudioSource effect;
    bool done;

    // Start is called before the first frame update
    void Start()
    {
        effect = gameObject.GetComponent<AudioSource>();
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere")
        {
            if (!done || repeat)
            {
                effect.Play();
                done = true;
            }
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.name == "Sphere")
    //    {

    //    }
    //}
}

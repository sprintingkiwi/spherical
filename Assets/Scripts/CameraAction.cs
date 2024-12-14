using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    CameraOrbit cam;
    bool zoom;
    float t;
    float min;
    float max;
    public float newDistance;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    IEnumerator Zoom(float targetDistance)
    {
        float dir = Mathf.Sign(cam.distance - targetDistance);

        while (Mathf.Abs(cam.distance - targetDistance) > 1f)
        {
            cam.distance += (speed * Time.deltaTime * -dir);
            yield return null;
        }

        cam.currentCameraAction = null;
        yield return null;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Sphere")
        {
            if (cam.currentCameraAction != null)
                StopCoroutine(cam.currentCameraAction);
            cam.currentCameraAction = StartCoroutine(Zoom(newDistance));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Sphere")
        {
            if (cam.currentCameraAction != null)
                StopCoroutine(cam.currentCameraAction);
            cam.currentCameraAction = StartCoroutine(Zoom(cam.defaultDistance));
        }        
    }
}

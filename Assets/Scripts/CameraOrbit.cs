using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraOrbit : MonoBehaviour
{
    Transform target;
    public float defaultDistance = 25f;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = 0.5f;
    public float distanceMax = 15f;

    public float xRotationOffset;
    public float xRotationMultiplier;
    public float yRotationOffset;
    public float yRotationMultiplier;

    public Coroutine currentCameraAction;

    Rigidbody rb;

    float x = 0.0f;
    float y = 0.0f;

    float mx;
    float my;
    float rHor;
    float rVer;

    // Use this for initialization
    void Start()
    {
        // FIND TARGET
        target = GameObject.Find("Sphere").transform;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rb = gameObject.GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        //mx = Input.GetAxis("Mouse X");
        //my = Input.GetAxis("Mouse Y");
        rHor = Input.GetAxis("Right Horizontal");
        rVer = Input.GetAxis("Right Vertical");
        if (target)
        {
            // MOUSE XY ROTATION CONTROL
            //x += mx * xSpeed * (distance / 2) * 0.02f;
            //y -= my * ySpeed * 0.02f;

            // RIGHT ANALOG ROTATION CONTROL
            x = (rHor * (distance / 2) * 0.02f * xRotationMultiplier) + yRotationOffset;
            y = (rVer * 0.02f * yRotationMultiplier) + xRotationOffset;            

            // LIMIT VERTICAL MOVEMENT
            if (target.GetComponent<SphereController>().onTheFloor == true)
            {
                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }
            

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            // ZOOM CAMERA
            //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            //if (Input.GetKey(KeyCode.Joystick1Button5))
            //{
            //    distance = distance + 1;
            //}
            //if (Input.GetKey(KeyCode.Joystick1Button4))
            //{
            //    distance = distance - 1;
            //}

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                //distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
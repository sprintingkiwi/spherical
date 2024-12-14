using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TouchInputManager : MonoBehaviour
{
    public SphereController playerController;
    bool upCheck;

	// Use this for initialization
	void Start ()
    {
        playerController = gameObject.GetComponent<SphereController>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // PERSISTENT TOUCH
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                playerController.powerButton = true;
            }
            else
            {
                playerController.powerButton = false;
            }

            // SINGLE TOUCH
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerController.powerButtonDown = true;
                upCheck = true;
            }
            else
            {
                playerController.powerButtonDown = false;
            }

            // TOUCH RELEASE
            if (Input.touchCount == 0 && playerController.powerButtonUp == false && upCheck == true)
            {
                playerController.powerButtonUp = true;
            }
            else if (playerController.powerButtonUp == true)
            {
                playerController.powerButtonUp = false;
                upCheck = false;
            }
            //Log(Input.GetTouch(0).phase.ToString());
        }
    }
}

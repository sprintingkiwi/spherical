using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    GameController gameController;
    Text mainLog;

    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        mainLog = GameObject.Find("Main Log").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Sphere" && other.isTrigger == false)
        {
            //mainLog.text = "CHECKPOINT";
            gameController.firstCheckpointTaken = true;
            gameController.SetLastCheckpoint(gameObject.GetComponent<Checkpoint>());
        }
    }
}

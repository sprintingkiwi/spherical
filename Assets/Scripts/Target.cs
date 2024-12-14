using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Target : MonoBehaviour {
    
    public string nextScene = "None";
    Scene actualScene;
    Text mainLog;

    // Use this for initialization
    void Start ()
    {
        // GET ACTUAL SCENE INDEX
        actualScene = SceneManager.GetActiveScene();

        // INIT MAIN LOG
        mainLog = GameObject.Find("Main Log").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            mainLog.text = "YOU WIN!";
            //if (nextScene != "None")
            //{
            //    SceneManager.LoadScene(nextScene);
            //}
            //else
            //{
            //    SceneManager.LoadScene(actualScene.buildIndex + 1);
            //}
        }
    }
}

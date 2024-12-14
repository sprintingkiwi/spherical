using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : SalioBehaviour
{
    public int level;
    GameObject player;
    SphereController playerController;
    public bool playerIsDead;
    PersistentStuff persistentStuff;
    public GameObject startButton;    
    Text timeLog;
    public List<GameObject> instructions = new List<GameObject>();
    GameObject persistentSounds;
    Vector3 randomPos;
    Vector3 newPosition;
    // COUNTER
    float startTime;
    float deltaTime;
    //CHECKPOINTS
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    public bool firstCheckpointTaken;


    // Use this for initialization
    void Start ()
    {
        persistentStuff = GameObject.Find("Persistent Stuff").GetComponent<PersistentStuff>();

        // ANDROID INIT
        if (Application.platform == RuntimePlatform.Android)
        {
            //Debug.Log(Input.GetTouch(0).phase);
            startButton.SetActive(true);
            Button btn = startButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        // INIT PLAYER
        player = GameObject.Find("Sphere");
        playerController = player.GetComponent<SphereController>();
        if (persistentStuff.needToLoadCheckpoint == true)
        {
            player.transform.position = persistentStuff.playerSavedPosition;
        }

        // TIME LOG
        startTime = Time.time;
        //timeLog = GameObject.Find("Time Log").GetComponent<Text>();

        // FOG
        RenderSettings.fog = persistentStuff.fog;

        // INSTRUCTIONS
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Instruction"))
        {
            instructions.Add(i);
        }

        //CHECKPOINTS
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Checkpoint"))
        {
            checkpoints.Add(i.GetComponent<Checkpoint>());
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // TIME
        deltaTime = Time.time - startTime;
        //timeLog.text = deltaTime.ToString("F1");
        if (deltaTime > 10)
        {
            foreach (GameObject i in instructions)
            {
                i.SetActive(false);
            }
        }

        // RESTART COMMAND
        if (Input.GetButtonDown("Submit"))
        {
            LoadCheckpoint();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // CHECKPOINTS NEVER RELOAD SCENE:
            if (firstCheckpointTaken == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                playerController.rb.velocity = Vector3.zero;
                playerController.transform.position = checkpoints[0].transform.position;
                if (playerIsDead == true)
                {
                    playerController.Resurrect();
                }
            }
        }

        // DEBUG CHEATS
        if (Input.GetKeyDown(KeyCode.R))
        {
            persistentStuff.needToLoadCheckpoint = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Scene actualScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(actualScene.buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Scene actualScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(actualScene.buildIndex - 1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (persistentSounds.activeSelf == true)
            {
                persistentSounds.SetActive(false);
            }
            else
            {
                persistentSounds.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (RenderSettings.fog == true)
            {
                RenderSettings.fog = false;
                persistentStuff.fog = false;
            }
            else
            {
                RenderSettings.fog = true;
                persistentStuff.fog = true;
            }
        }        
    }

    // START BUTTON BEHAVIOR
    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("restart game");
    }

    // SET LAST CHECKPOINT
    public void SetLastCheckpoint (Checkpoint c)
    {
        checkpoints.Insert(0, c);
    }

    public void LoadCheckpoint()
    {
        // RELOAD SCENE and go to last checkpoint position             
        if (firstCheckpointTaken == true)
        {
            persistentStuff.playerSavedPosition = checkpoints[0].transform.position;
            persistentStuff.needToLoadCheckpoint = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // FUNCTION CALLED BY TRIGGER SENSORS
    public override void TriggerSensor(string sensor, Collider other, string type)
    {
        if (sensor == "Game Box")
        {
            if (other.name == player.name)
            {
                if (type == "Exit")
                {
                    LoadCheckpoint();
                }
            }
        }
    }
}

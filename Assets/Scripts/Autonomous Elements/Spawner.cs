using UnityEngine;
using System.Collections;

public class Spawner : AutonomousElement
{       
    public float spawnStartTime;
    public float spawnRate;
    public GameObject objectToSpawn;
    public int unitsPerSpawn;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        Spawn();
    }

    // SPAWN
    public virtual void Spawn()
    {
        if (Time.time - spawnStartTime >= spawnRate)
        {
            spawnStartTime = Time.time;
            for (int i = 0; i < unitsPerSpawn; i++)
            {
                Vector3 starDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                GameObject s = Instantiate(objectToSpawn, transform.position, transform.rotation, transform) as GameObject;
                SpawnOptions(s);
            }
        }
    }

    public virtual void SpawnOptions(GameObject s)
    {

    }
}

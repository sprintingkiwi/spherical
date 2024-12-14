using UnityEngine;
using System.Collections;

public class WorkerSpawner : Spawner
{
    public bool autonomousWorkers;
    public Vector3 workersFixedDirection;
    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    // SPAWN
    public override void SpawnOptions(GameObject s)
    {
        base.SpawnOptions(s);

        Worker w = s.GetComponent<Worker>();
        if (autonomousWorkers == true)
        {
            w.isAutonomous = true;
        }
        w.fixedDirection = workersFixedDirection;
    }
}

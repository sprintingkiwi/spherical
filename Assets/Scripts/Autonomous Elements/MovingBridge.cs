using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : Floor
{
    public bool loaded;
    public bool arrived;
    public float speed;
    public GameObject docking;
    public Vector3 startPos;
    public Vector3 endPos;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y, docking.transform.position.z);
	}

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();

        zLevel = transform.position.z;

        if (loaded == true)
        {
            if (arrived == false)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPos, step);
                if (Vector3.Distance(transform.position, endPos) < 0.1f)
                {
                    endPos = startPos;
                    startPos = transform.position;
                    arrived = true;
                }
            }
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.name == player.name)
        {
            playerController.rb.constraints = RigidbodyConstraints.None;
            player.transform.SetParent(transform, true);
            loaded = true;
            arrived = false;
        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.name == player.name)
        {
            playerController.rb.constraints = RigidbodyConstraints.FreezePositionZ;
            player.transform.SetParent(GameObject.Find("MAIN OBJECTS").transform);
            loaded = false;
        }
    }
}

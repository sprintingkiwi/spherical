using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveUnit : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 randomPos;
    public float speed;
    SlaveUnitRange range;

    // Use this for initialization
    void Start ()
    {
        targetPos = transform.position;
        randomPos = transform.position + new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        range = GetComponentInChildren<SlaveUnitRange>();
    }

    // Update is called once per frame
    void Update ()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == targetPos)
        {
            range.completingMovement = false;
        }
        if (range.inRange == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
        else if (range.inRange == false && range.completingMovement == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, randomPos, step);
        }
    }
}

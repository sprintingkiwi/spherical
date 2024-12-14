using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCubes : MonoBehaviour
{
    public Transform unit;
    int xScaleRatio;
    int yScaleRatio;
    int zScaleRatio;
    float xStart;
    float yStart;
    float zStart;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        xScaleRatio = Mathf.RoundToInt(transform.localScale.x / unit.localScale.x);
        yScaleRatio = Mathf.RoundToInt(transform.localScale.y / unit.localScale.y);
        zScaleRatio = Mathf.RoundToInt(transform.localScale.z / unit.localScale.z);

        xStart = transform.position.x - (transform.localScale.x / 2) + (unit.localScale.x / 2);
        yStart = transform.position.y - (transform.localScale.y / 2) + (unit.localScale.y / 2);
        zStart = transform.position.z - (transform.localScale.z / 2) + (unit.localScale.z / 2);

        for (int i = 0; i < xScaleRatio; i++)
        {
            Vector3 pos = new Vector3((xStart + (unit.localScale.x * i)), yStart, zStart);
            Instantiate(unit, pos, Quaternion.identity, GameObject.Find("STATIC ELEMENTS").transform);
        }
        for (int i = 0; i < yScaleRatio; i++)
        {
            Vector3 pos = new Vector3(xStart, (yStart + (unit.localScale.x * i)), zStart);
            Instantiate(unit, pos, Quaternion.identity, GameObject.Find("STATIC ELEMENTS").transform);
        }
        for (int i = 0; i < zScaleRatio; i++)
        {
            Vector3 pos = new Vector3(xStart, yStart, (zStart + (unit.localScale.x * i)));
            Instantiate(unit, pos, Quaternion.identity, GameObject.Find("STATIC ELEMENTS").transform);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

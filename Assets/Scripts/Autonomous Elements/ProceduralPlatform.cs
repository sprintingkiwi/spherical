using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ProceduralPlatform : AutonomousElement
{
    public GameObject supports;
    public float supPosYOffset;
    public float supPosZOffset;
    public int supportDensity;
    public bool totallyTilable;
    public int xLength;
    public int yLength;
    public int zLength;
    public GameObject startUnit;
    public GameObject midUnit;
    public GameObject endUnit;
    public Vector3 totalSize;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
        foreach (Collider c in gameObject.GetComponents<Collider>())
        {
            DestroyImmediate(c);
        }

        Vector3 startPos = new Vector3((transform.position.x - transform.localScale.x / 2) + (midUnit.transform.localScale.x / 2), (transform.position.y - transform.localScale.y / 2) + (midUnit.transform.localScale.x / 2), (transform.position.z - transform.localScale.z / 2) + (midUnit.transform.localScale.x / 2));
        xLength = Mathf.RoundToInt(transform.localScale.x);
        yLength = Mathf.RoundToInt(transform.localScale.y);
        zLength = Mathf.RoundToInt(transform.localScale.z);
        transform.localScale = Vector3.one;
        DestroyImmediate(gameObject.GetComponent<MeshFilter>());
        DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
        totalSize = new Vector3(xLength * midUnit.transform.localScale.x, yLength * midUnit.transform.localScale.y, zLength * midUnit.transform.localScale.z);

        // FIRST TYPE OF PROCEDURAL PLATFORM
        if (totallyTilable == false)
        {
            // Instantiate Support GameObjects
            Vector3 supportPos = new Vector3(startPos.x, startPos.y + supPosYOffset, startPos.z + supPosZOffset);
            float deltaX = totalSize.x / (supportDensity * totalSize.x/100);
            while (supportPos.x <= startPos.x + totalSize.x)
            {
                Instantiate(supports, supportPos, Quaternion.identity, transform);
                supportPos = new Vector3(supportPos.x + deltaX, supportPos.y, supportPos.z);
            }

            // Instantiate Start Unit
            Instantiate(startUnit, startPos, Quaternion.identity, transform);
            
            // Instantiate Middle Units
            for (int i = 1; i < (xLength - 1); i++)
            {
                Vector3 nextPosX = new Vector3(startPos.x + (midUnit.transform.localScale.x * i), startPos.y, startPos.z);
                Instantiate(midUnit, nextPosX, Quaternion.identity, transform);
            }

            // Instantiate End Unit
            Vector3 endPos = new Vector3(startPos.x + (midUnit.transform.localScale.x * (xLength - 1)), startPos.y, startPos.z);
            Instantiate(endUnit, endPos, Quaternion.identity, transform);

            // Creating Colliders
            // Collisions
            BoxCollider floorCollider = gameObject.AddComponent<BoxCollider>();
            floorCollider.size = totalSize;
            //floorCollider.center = new Vector3((midUnit.transform.localScale.x * (xLength - 1) / 2), 0f, 0f);

            // Trigger
            //BoxCollider floorTrigger = gameObject.AddComponent<BoxCollider>();
            //floorTrigger.isTrigger = true;
            //floorTrigger.size = totalSize + new Vector3(0.5f, 0.5f, 0.5f);
            //floorTrigger.size = new Vector3(xLength + (xLength/50), yLength + (yLength / 50), zLength + (zLength / 50));
            //floorTrigger.center = new Vector3((midUnit.transform.localScale.x * (xLength - 1) / 2), 0f, 0f);
        }

        else if (totallyTilable == true)
        {
            for (int i = 1; i < (xLength); i++)
            {
                Vector3 nextPosX = new Vector3(startPos.x + (midUnit.transform.localScale.x * i), startPos.y, startPos.z);
                Instantiate(midUnit, nextPosX, Quaternion.identity, transform);
                for (int l = 1; l < (yLength); l++)
                {
                    Vector3 nextPosY = new Vector3(nextPosX.x, startPos.y + (midUnit.transform.localScale.y * l), startPos.z);
                    Instantiate(midUnit, nextPosY, Quaternion.identity, transform);
                    for (int m = 1; m < (zLength); m++)
                    {
                        Vector3 nextPosZ = new Vector3(nextPosX.x, nextPosY.y, startPos.z + (midUnit.transform.localScale.z * m));
                        Instantiate(midUnit, nextPosZ, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
	}
}

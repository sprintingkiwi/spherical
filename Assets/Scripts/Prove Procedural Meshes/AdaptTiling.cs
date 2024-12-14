using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AdaptTiling : MonoBehaviour
{
    Material originalMaterial;
    Material newMaterial;
    public float textureRatio;

    // Use this for initialization
    void Start ()
    {
        originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        newMaterial = Instantiate(originalMaterial);
        newMaterial.mainTextureScale = new Vector2(transform.localScale.x / textureRatio, transform.localScale.y / textureRatio);
        gameObject.GetComponent<MeshRenderer>().material = newMaterial;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

using UnityEngine;
using System.Collections;

public class PersistentStuff : MonoBehaviour
{
    public static PersistentStuff cGInstance;
    public bool needToLoadCheckpoint;
    public Vector3 playerSavedPosition;
    public bool fog;

    void Awake()
    {
        if (cGInstance == null)
        {
            cGInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}

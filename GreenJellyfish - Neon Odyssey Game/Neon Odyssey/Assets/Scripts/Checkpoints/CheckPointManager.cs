using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    //--------------------------------------------------------------
    //-Attach script to CHECKPOINT MANAGER prefab
    //--------------------------------------------------------------

    public Vector3 currentCheckpoint = Vector3.zero;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void setCurrentCheckpoint(Vector3 pos)
    {
        currentCheckpoint = pos;
    }
}

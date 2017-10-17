using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    /*
     * ATTACH SCRIPT TO 'CP Manager' GAME OBJECT OR EMPTY GAME OBJECT
     */
    public Vector3 currentCheckpoint = Vector3.zero;


	// Use this for initialization
	void Start () {

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

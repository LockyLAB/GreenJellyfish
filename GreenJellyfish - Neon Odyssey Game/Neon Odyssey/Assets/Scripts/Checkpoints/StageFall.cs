using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFall : MonoBehaviour
{
    //=============================================================
    //-Attach this script to CHECKPOINT prefab
    //Plug in CHECKPOINT MANAGER gameobject from SCENE
    //=============================================================

    public CheckPointManager CPmanager1;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1Revive" || other.gameObject.tag == "Player2Revive")
        {
            other.gameObject.transform.parent.position = CPmanager1.currentCheckpoint;
        }
    }
}

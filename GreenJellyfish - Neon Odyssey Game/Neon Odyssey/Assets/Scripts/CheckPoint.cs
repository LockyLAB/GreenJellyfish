using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    //SET UP VARIABLES
    //check if player has fallen off the stage
    //reset player health
    //remove life
    //get current transform of checkpoint
    //set respawn here
    //check if respawn pt reached
    //change colour of checkpoint
    //set last triggered checkpoint to be active

     Vector3 pos;
     Vector3 pos2;
     Transform currentCheckpoint;



	// Use this for initialization
	void Start () {
        //currentCheckpoint = GameObject.FindGameObjectWithTag("Checkpt");
        pos = this.transform.position;
        pos2 = pos;
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        //foreach (var chkpt in currentCheckpoint)
        //{
        //    if (col.gameObject.tag == "Checkpt")
        //    {
        //        chkpt.transform.position = setCurrentCheckpoint();
        //    }
        //    Debug.Log(chkpt.transform.position);
        //}

        if(col.gameObject.tag == "Player1Revive" || col.gameObject.tag == "Player2Revive")
        {
            Debug.Log("pos of this cp" + pos);
            pos = setCurrentCheckpoint();
            Debug.Log(currentCheckpoint);
        }
    }

    public Vector3 setCurrentCheckpoint()
    {
        pos2 = pos;
        Debug.Log("pos2: " + pos2);
        return pos2;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//--------------------------------------------------------------
// 1. Attach this script to CHECKPOINT prefab
// 2. Plug in CHECKPOINT MANAGER gameobject from SCENE
//--------------------------------------------------------------

public class CheckPoint : MonoBehaviour
{

    public CheckPointManager CPmanager;
    public Vector3 pos;    
    public Vector3 setPos;

	void Start ()
    {
        //this.GetComponentInChildren<MeshRenderer>().material = cpMaterial[0]; //set default colour
        pos = this.transform.position; //set pos of this checkpoint
	}
    
    void OnTriggerEnter(Collider other) //set current checkpoint to this
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>())
        {
            CPmanager.setCurrentCheckpoint(other.gameObject.transform.position);
            //this.GetComponentInChildren<MeshRenderer>().material = cpMaterial[1]; //set alt colour when activated
        }

    }


    
    
    
}

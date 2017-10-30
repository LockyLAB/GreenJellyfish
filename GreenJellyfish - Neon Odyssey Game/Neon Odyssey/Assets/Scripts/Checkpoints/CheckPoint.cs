using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //--------------------------------------------------------------
    //-Attach this script to CHECKPOINT prefab
    //-Plug in CHECKPOINT MANAGER gameobject from SCENE
    //--------------------------------------------------------------

    public CheckPointManager CPmanager;
    public Vector3 pos;    //position of this cp
    public Vector3 setPos;

    //public Material[] cpMaterial;

	// Use this for initialization
	void Start ()
    {
        //this.GetComponentInChildren<MeshRenderer>().material = cpMaterial[0]; //set default colour
        pos = this.transform.position; //set pos of this checkpoint
        Renderer rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CPmanager.setCurrentCheckpoint(other.gameObject.transform.position);
            Debug.Log("cp set " + pos);
            //this.GetComponentInChildren<MeshRenderer>().material = cpMaterial[1]; //set alt colour when activated
        }
    }


    
    
    
}

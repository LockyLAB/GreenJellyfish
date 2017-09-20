using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject POI;

    private Vector3 offset;

    // Use this for initialization
	void Start ()
    {
        offset = new Vector3(0, 0, -10);
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = POI.transform.position + offset;
	}


}

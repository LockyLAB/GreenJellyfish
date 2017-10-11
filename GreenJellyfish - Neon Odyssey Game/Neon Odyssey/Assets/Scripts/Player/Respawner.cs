using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    GameObject pc;
    public GameObject checkpoint;

	// Use this for initialization
	void Start () {
        pc = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(!pc.activeInHierarchy)
        {
            pc.transform.position = checkpoint.GetComponent<CheckPoint>().setCurrentCheckpoint();
            pc.SetActive(true);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Deathzone")
        {
           Debug.Log("test");
            pc.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallzone : MonoBehaviour
{
    //public Transform checkpoint;
    //Vector3 cpVector = GameObject.FindGameObjectWithTag("Checkpt").transform.position;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		//if(!p1.activeInHierarchy)
        //{
        //    p1.transform.position = checkpoint.gameObject.GetComponent<CheckPoint>().setCurrentCheckpoint();
        //    p1.SetActive(true);
        //}
	}

    void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.tag == "Player")
        //{
        //    Debug.Log("offstage");
        //    col.gameObject.SetActive(false);
        //    
        //    
        //    //col.gameObject.transform.position = 
        //    //col.gameObject.transform.position = GetComponent<CheckPoint>().setCurrentCheckpoint();
        //}
    
       // if(col.gameObject.tag == "Player")
       // {
       //     
       // }
    }
}

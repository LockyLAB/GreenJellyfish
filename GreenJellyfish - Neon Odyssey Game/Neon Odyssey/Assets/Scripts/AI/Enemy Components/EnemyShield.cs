using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//-----------------------------------------------------------------------------
// Attach to enemy gameObject
//-----------------------------------------------------------------------------

public class EnemyShield : MonoBehaviour {

    //use if list size is static
    public GameObject[] shieldList = new GameObject[4];

    //shields spawn location
    public Transform shieldPos;

    //shield health
    public int shieldCharge;

    // Use this for initialization
    void Start () {

        Instantiate(shieldList[Random.Range(0, shieldList.Length - 1)], 
                    shieldPos.position, 
                    shieldPos.rotation,
                    transform);
        
	}
	
	// Update is called once per frame
	void Update () {

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Edward
//-contributors:
//---------------------------------------------------------

public class RayshieldEntry : MonoBehaviour {

    public GameObject shield;

    private GameObject playerOne;
    private GameObject playerTwo;

    private bool p1trigger = false;
    private bool p2trigger = false;

	// Use this for initialization
	void Start ()
    {
        playerOne = GameObject.Find("Anubis");
        playerTwo = GameObject.Find("Horus");
        shield.SetActive(false);
	}

    void Update()
    {
        if (p1trigger == true && p2trigger == true)
        {
            shield.SetActive(true);  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerOne)
        {
            p1trigger = true;
        }

        if (other.gameObject == playerTwo)
        {
            p2trigger = true;
        }
    }



}

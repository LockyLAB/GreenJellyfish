using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ColourController : MonoBehaviour {

    public enum Colours
    {
        Red = 1,
        Green = 2
    }

    public int switchColour = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchColour = (int)Colours.Red;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchColour = (int)Colours.Green;
        }

    }
}

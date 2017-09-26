using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2ColourController : MonoBehaviour {

    public enum Colours
    {
        Yellow = 1,
        Purple = 2
    }

    public int switchColour = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchColour = (int)Colours.Yellow;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchColour = (int)Colours.Purple;
        }
    }
}

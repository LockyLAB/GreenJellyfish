using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour {

    public enum Colours
    {
        Red = 1,
        Green = 2,
        Yellow = 3,
        Purple = 4
    }

    public int switchColour = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
           switchColour = (int)Colours.Red;
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha2))
       {
           switchColour = (int)Colours.Green;
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha3))
       {
           switchColour = (int)Colours.Yellow;
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha4))
       {
           switchColour = (int)Colours.Purple;
       }
    }

}

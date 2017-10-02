using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class P1ColourController : MonoBehaviour {

    public enum Colours
    {
        Red = 1,
        Green = 2
    }

    bool isRed = true;
    public bool isToggled;

    public int switchColour = 1;

    // Use this for initialization
    void Start () {
        
	}


    // Update is called once per frame
    void Update () {
        isToggled = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchColour = (int)Colours.Red;
            isToggled = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchColour = (int)Colours.Green;
            isToggled = true;
      }


        
    
    //              XBOX CONTROLS
    //if (isRed)
    //{
    //    if (XCI.GetButtonDown(XboxButton.LeftBumper))
    //    {
    //        switchColour = (int)Colours.Red;
    //        isRed = false;
    //        isToggled = true;
    //        }
    //}
    //else
    //{
    //    if (XCI.GetButtonDown(XboxButton.LeftBumper))
    //    {
    //        switchColour = (int)Colours.Green;
    //        isRed = true;
    //        isToggled = true;
    //        }
    //}
    //    
    //
    }
}

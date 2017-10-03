using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class P2ColourController : MonoBehaviour
{
    public XboxController controller;

    //INPUT P2 CHAR COLOUR 1 + 2
    public Material[] playerMaterial = new Material[2];

    //INPUT CHARACTER MODEL
    public GameObject characterModel;

    //P2 COLOURS
    public enum Colours
    {
        Orange = 1,
        Green = 2
    }

    //MISC VARIABLES
    private bool isDefault;
    public bool isToggled;
    public int switchColour = 1;

    // Use this for initialization
    void Start()
    {
        isDefault = true;
        switchColour = 1;
        changeMaterial();
    }

    // Update is called once per frame
    void Update()
    {

        isToggled = false;

        //XBOX CONTROLS
        if (isDefault)
        {
            if (XCI.GetButton(XboxButton.LeftBumper, controller) || XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) != 0)
            {
                switchColour = (int)Colours.Orange;
                isDefault = false;
                isToggled = true;
                switchColour = 1;
                changeMaterial();
            }
        }
        else
        {
            if (XCI.GetButton(XboxButton.LeftBumper, controller) || XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) != 0)
            {
                switchColour = (int)Colours.Green;
                isDefault = true;
                isToggled = true;
                switchColour = 2;
                changeMaterial();
            }
        }
    }

        //CHANGES MATERIAL OF CHARACTER
    void changeMaterial()
    {
        if(switchColour == 1)
        {
            characterModel.GetComponent<MeshRenderer>().material = playerMaterial[0];
        }
        if (switchColour == 2)
        {
            characterModel.GetComponent<MeshRenderer>().material = playerMaterial[1];
        }
    }     
}






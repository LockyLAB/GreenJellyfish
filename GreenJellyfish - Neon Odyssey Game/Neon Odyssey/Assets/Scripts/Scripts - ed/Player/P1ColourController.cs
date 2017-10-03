using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class P1ColourController : MonoBehaviour
{
    public XboxController controller;
    float timeToSwitch = 0;

    //INPUT P1 CHAR COLOUR 1 + 2
    public Material[] playerMaterial = new Material[2];

    
    //INPUT CHARACTER MODEL
    public GameObject characterModel;

    //P1 COLOURS
    public enum Colours
    {
        Pink = 1,
        Yellow = 2
    }

    //MISC VARIABLES
    bool isDefault ;
    public bool isToggled;
    public int switchColour;

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

        //isToggled = false;

        //TOGGLE PLAYER COLOUR
        if (isDefault)
        {
            timeToSwitch += Time.deltaTime;
            if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) != 0 && timeToSwitch >= 0.3)
            {
                switchColour = (int)Colours.Pink;
                isDefault = false;
                //isToggled = true;
                switchColour = 2;
                changeMaterial();
                timeToSwitch = 0;
            }
        }
        else
        {
            timeToSwitch += Time.deltaTime;
            if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) != 0 && timeToSwitch >= 0.3)
            {
                switchColour = (int)Colours.Yellow;
                isDefault = true;
                //isToggled = true;
                switchColour = 1; 
                changeMaterial();
                timeToSwitch = 0;
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


   
        
    

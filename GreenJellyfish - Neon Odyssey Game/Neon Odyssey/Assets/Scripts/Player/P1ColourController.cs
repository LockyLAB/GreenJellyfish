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
        toggleMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        //TOGGLE PLAYER COLOUR
        if (isDefault)
        {
            timeToSwitch += Time.deltaTime;
            if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.RightBumper, controller) && timeToSwitch >= 0.3)
            {
                switchColour = (int)Colours.Pink;
                isDefault = false;
                switchColour = 2;
                toggleMaterial();
                timeToSwitch = 0;
            }
        }
        else
        {
            timeToSwitch += Time.deltaTime;
            if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.RightBumper, controller) && timeToSwitch >= 0.3)
            {
                switchColour = (int)Colours.Yellow;
                isDefault = true;
                switchColour = 1;
                toggleMaterial();
                timeToSwitch = 0;
            }
        }
    }

    //TOGGLES CHARACTER MATERIAL
    void toggleMaterial()
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

    //TOGGLES CHARACTER TAG
    void toggleTag()
    {
        if(switchColour == 1)
        {
            gameObject.tag = "playerPink";
        }

        if(switchColour == 2)
        {
            gameObject.tag = "playerYellow";
        }
    }


}


   
        
    

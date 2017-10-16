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

    public Player player;

    //P1 COLOURS
    public enum Colours
    {
        Purple = 1,
        Orange = 2
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
        toggleMaterial();
        toggleLayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            //TOGGLE PLAYER COLOUR
            if (isDefault)
            {
                timeToSwitch += Time.deltaTime;
                if (XCI.GetButton(XboxButton.LeftStick, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.RightStick, controller) && timeToSwitch >= 0.3)
                {
                    switchColour = (int)Colours.Purple;
                    isDefault = false;
                    toggleMaterial();
                    toggleLayer();
                    timeToSwitch = 0;
                }
            }
            else
            {
                timeToSwitch += Time.deltaTime;
                if (XCI.GetButton(XboxButton.LeftStick, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.RightStick, controller) && timeToSwitch >= 0.3)
                {
                    switchColour = (int)Colours.Orange;
                    isDefault = true;
                    toggleMaterial();
                    toggleLayer();
                    timeToSwitch = 0;
                }
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

    //TOGGLES CHARACTER LAYER
    void toggleLayer()
    {
        if(switchColour == 1)
        {
            gameObject.layer = 9;
        }

        if(switchColour == 2)
        {
            gameObject.layer = 11;
        }
    }

}


   
        
    

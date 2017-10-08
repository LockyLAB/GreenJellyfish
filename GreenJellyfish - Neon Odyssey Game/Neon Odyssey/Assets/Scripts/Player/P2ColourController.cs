using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class P2ColourController : MonoBehaviour
{
    public XboxController controller;
    float timeToSwitch = 0;

    //INPUT P2 CHAR COLOUR 1 + 2
    public Material[] playerMaterial = new Material[2];

    //INPUT CHARACTER MODEL
    public GameObject characterModel;

    public Player player;

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
        toggleMaterial();
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
                if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3)
                {
                    switchColour = (int)Colours.Orange;
                    isDefault = false;
                    switchColour = 1;
                    toggleMaterial();
                    timeToSwitch = 0;
                }
            }
            else
            {
                timeToSwitch += Time.deltaTime;
                if (XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.LeftBumper, controller) && timeToSwitch >= 0.3)
                {
                    switchColour = (int)Colours.Green;
                    isDefault = true;
                    switchColour = 2;
                    toggleMaterial();
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

    //TOGGLES CHARACTER TAG
    void toggleTag()
    {
        if (switchColour == 1)
        {
            gameObject.tag = "playerOrange";
        }

        if (switchColour == 2)
        {
            gameObject.tag = "playerGreen";
        }
    }
}






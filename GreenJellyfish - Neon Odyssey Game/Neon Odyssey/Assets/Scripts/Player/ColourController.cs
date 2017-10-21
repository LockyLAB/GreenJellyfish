using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ColourController : MonoBehaviour
{
    public XboxController controller;
    float timeToSwitch = 0;

    //All four materials, Purple, Pink, Orange, Green
    public Material[] playerMaterial;

    //MISC VARIABLES
    public bool m_firstBulletSlot = true;

    public void Awake()
    {
        toggleColour();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Player>().isDead)
        {
            //TOGGLE PLAYER COLOUR
            timeToSwitch += Time.deltaTime;

            if (XCI.GetButton(XboxButton.LeftStick, controller) && timeToSwitch >= 0.3 || XCI.GetButton(XboxButton.RightStick, controller) && timeToSwitch >= 0.3)
            {
                toggleColour();
                timeToSwitch = 0.0f;
            }
        }
    }

    //TOGGLES CHARACTER MATERIAL
    void toggleColour()
    {
        m_firstBulletSlot = !m_firstBulletSlot;
        if (GetComponent<Player>().isFirstPlayer)
        {
            if(m_firstBulletSlot)
            {
                GetComponentInChildren<MeshRenderer>().material = playerMaterial[0];
                gameObject.layer = LayerMask.NameToLayer("Purple");
            }
            else
            {
                GetComponentInChildren<MeshRenderer>().material = playerMaterial[1];
                gameObject.layer = LayerMask.NameToLayer("Orange");
            }
        }
        else
        {
            if (m_firstBulletSlot)
            {
                GetComponentInChildren<MeshRenderer>().material = playerMaterial[0];
                gameObject.layer = LayerMask.NameToLayer("Green");
            }
            else
            {
                GetComponentInChildren<MeshRenderer>().material = playerMaterial[1];
                gameObject.layer = LayerMask.NameToLayer("Pink");
            }
        }
    }
}

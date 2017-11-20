using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ControlScreenManager : MonoBehaviour {

    //--------------------------------------------------------------------------------------
    // Update
    // Return to game scene
    //--------------------------------------------------------------------------------------
    public void Update()
    {

        if (XCI.GetButtonDown(XboxButton.Back))
        {
            Time.timeScale = 1.0f;
            this.gameObject.SetActive(false);
        }
    }
}

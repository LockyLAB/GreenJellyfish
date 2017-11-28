using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//-----------------------------------------------------------------------------
// Attach script to player gameobject
//-----------------------------------------------------------------------------

public class PlayerSuper : MonoBehaviour {

    private float startCharge = 0f;
    public float currentCharge;

    public Text powerChargeDisplay;
    public Image powerBarFill;
    public Image powerBarBackground;

    //private int p1;
    //private int p2;

	void Start () {

        currentCharge = startCharge;
	}
	
    //set charge UI to respective player
	void Update () {

        if ( gameObject.GetComponent<Player>().isFirstPlayer == true )
        {
            powerBarFill.fillAmount = currentCharge / 100;
            powerChargeDisplay.text = currentCharge.ToString("F0") + "%";
        }   

        if ( gameObject.GetComponent<Player>().isFirstPlayer == false )
        {
            powerBarFill.fillAmount = currentCharge / 100;
            powerChargeDisplay.text = currentCharge.ToString("F0") + "%";
        }
	}

    //update charge
    public void ChangeCharge(float num)
    {
        currentCharge += num;
    }

}

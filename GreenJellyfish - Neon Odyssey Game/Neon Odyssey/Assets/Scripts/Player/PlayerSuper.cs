using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSuper : MonoBehaviour {

    private float startCharge = 0f;
    public float currentCharge;

    public Text powerChargeDisplay;
    public Image powerBarFill;
    public Image powerBarBackground;

    private int p1;
    private int p2;

	// Use this for initialization
	void Start () {

        currentCharge = startCharge;

	}
	
	// Update is called once per frame
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

    public void ChangeCharge(float num)
    {
        currentCharge += num;
    }

}

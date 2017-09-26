using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Delete : MonoBehaviour {

    public enum Colors
    {
        Red,
        Blue,
        Green
    }
    Colors[] color;
    public int[] switchColors;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.A))
        {
            for (int i = 0; i < 3; ++i)
            {

            }
        }
		
	}
}

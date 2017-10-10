using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayGameBtn()
    {
        SceneManager.LoadScene("Greybox");
    }
    public void OptionsBtn()
    {

    }
    public void QuitBtn()
    {
        Application.Quit();
    }

}

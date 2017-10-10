using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("ChangeToMainMenu", 4);
    }

    void ChangeToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

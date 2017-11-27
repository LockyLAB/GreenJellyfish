using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NO LONGER IMPLEMENTED

public class SplashScreenManager : MonoBehaviour {

    //--------------------------------------------------------------------------------------
    // Splash screen to display game logo
    //--------------------------------------------------------------------------------------
    void Start ()
    {
        Invoke("ChangeToMainMenu", 4);
    }

    //--------------------------------------------------------------------------------------
    // After timer move to main menu scene
    //--------------------------------------------------------------------------------------
    void ChangeToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

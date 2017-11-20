using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public string m_firstLevel = "";

    //--------------------------------------------------------------------------------------
    // Load first level
    //--------------------------------------------------------------------------------------
    public void PlayGameBtn()
    {
        SceneManager.LoadScene(m_firstLevel);
    }

    //--------------------------------------------------------------------------------------
    // Options menu TODO
    //--------------------------------------------------------------------------------------
    public void OptionsBtn()
    {

    }

    //--------------------------------------------------------------------------------------
    // Quit application
    //--------------------------------------------------------------------------------------
    public void QuitBtn()
    {
        Application.Quit();
    }

}

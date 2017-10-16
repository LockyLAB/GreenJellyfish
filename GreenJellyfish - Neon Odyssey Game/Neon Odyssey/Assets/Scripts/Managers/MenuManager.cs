using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public string m_firstLevel = "";

    public void PlayGameBtn()
    {
        SceneManager.LoadScene(m_firstLevel);
    }
    public void OptionsBtn()
    {

    }
    public void QuitBtn()
    {
        Application.Quit();
    }

}

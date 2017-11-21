using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MenuManager : MonoBehaviour
{

    public string m_firstLevel = "";

    public Image m_splashImage = null;

    public float m_splashFadeTime = 2.0f;
    private float m_splashFadeTimer = 0.0f;

    private bool m_splashFade = false;

    //Main menu stuff
    public Image m_PlayBtnImg;
    public Image m_QuitBtnImg;

    public Button m_PlayBtn;
    public Button m_QuitBtn;

    private void Update()
    {
        //Pausing Screen
        if (XCI.GetButtonDown(XboxButton.Start))
        {
            m_splashFade = true;
        }

        if(m_splashFade && m_splashFadeTimer > m_splashFadeTime)
        {
            float alpha = m_splashFadeTimer / m_splashFadeTime;
            Color tempColor = m_splashImage.color;
            tempColor.a = 1- alpha;
            m_splashImage.color = tempColor;
        }
    }

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

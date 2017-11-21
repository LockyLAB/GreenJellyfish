using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MenuManager : MonoBehaviour
{

    public string m_firstLevel = "";

    public Image m_startImg = null;

    public float m_startFadeTime = 2.0f;
    private float m_startFadeTimer = 0.0f;

    private bool m_startFade = false;

    public float m_menuFadeTime = 2.0f;
    private float m_menuFadeTimer = 0.0f;
    private bool m_menuFade = false;

    //Main menu stuff
    public Image m_PlayBtnImg;
    public Image m_ControllerBtnImg;
    public Image m_QuitBtnImg;

    private void Update()
    {
        //Pausing Screen
        if (XCI.GetButtonDown(XboxButton.Start))
        {
            m_startFade = true;
        }

        if(m_startFade && m_startFadeTimer < m_startFadeTime)
        {
            m_startFadeTimer += Time.deltaTime;
            float alpha = m_startFadeTimer / m_startFadeTime;

            SetAlpha(1 - alpha, m_startImg);

            if(m_startFadeTimer > m_startFadeTime)
            {
                m_PlayBtnImg.gameObject.SetActive(true);
                m_QuitBtnImg.gameObject.SetActive(true);
                SetAlpha(0, m_PlayBtnImg);
                SetAlpha(0, m_QuitBtnImg);
                m_menuFade = true;

                //Set up event System
                GameObject eventSystem = GameObject.Find("EventSystem");
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(m_PlayBtnImg.gameObject);
            }
        }

        if (m_menuFade && m_menuFadeTimer < m_menuFadeTime)
        {
            m_menuFadeTimer += Time.deltaTime;
            float alpha = m_menuFadeTimer / m_menuFadeTime;

            SetAlpha(alpha, m_PlayBtnImg);
            //SetAlpha(alpha, m_ControllerBtnImg);
            SetAlpha(alpha, m_QuitBtnImg);
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

    private void SetAlpha(float alpha, Image image)
    {
        Color tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MenuManager : MonoBehaviour
{
    //String to load first level
    public string m_firstLevel = "";

    //Music
    public GameObject m_menuMusicLoop = null;
    public GameObject m_playMusicLoop = null;

    public Image m_startImg = null; //Splash Screen

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

    public Image m_fadeImage;

    //Playing game setup 
    private bool m_startGame = false;
    public float m_startGameTime = 9.0f;
    private float m_startGameTimer = 0.0f;

    private void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    //--------------------------------------------------------------------------------------
    // Animation of fading in buttons
    //--------------------------------------------------------------------------------------
    private void Update()
    {
        //Pausing Screen
        if (XCI.GetButtonDown(XboxButton.Start))
        {
            m_startFade = true;
        }

        if(m_startFade && m_startFadeTimer < m_startFadeTime) // Fading start button away 
        {
            m_startFadeTimer += Time.deltaTime;
            float alpha = m_startFadeTimer / m_startFadeTime;

            SetAlpha(1 - alpha, m_startImg);

            if(m_startFadeTimer >= m_startFadeTime)
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

        if (m_menuFade && m_menuFadeTimer < m_menuFadeTime) // Fading play and quit buttons, fade in controller
        {
            m_menuFadeTimer += Time.deltaTime;
            float alpha = m_menuFadeTimer / m_menuFadeTime;

            SetAlpha(alpha, m_PlayBtnImg);
            SetAlpha(alpha, m_QuitBtnImg);
        }

        if(m_startGame && m_startGameTimer < m_startGameTime) // Play music
        {
            m_startGameTimer += Time.deltaTime;

            if (m_startGameTimer < 1.4) //Fade in controller
            {
                float alpha = m_startGameTimer / 2.0f;
                SetAlpha(alpha, m_fadeImage);
                SetAlpha(0.7f - alpha, m_startImg);
            }

            if (m_startGameTimer < 2.0f) //Fade in controller
            {
                float alpha = m_startGameTimer / 2.0f;
                SetAlpha(alpha, m_ControllerBtnImg);
            }

            if (m_startGameTimer >= m_startGameTime)
            {
                SceneManager.LoadScene(m_firstLevel); // Load level after 9 seconds
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // Load first level
    //--------------------------------------------------------------------------------------
    public void PlayGameBtn()
    {
        m_startGame = true;
        m_menuMusicLoop.GetComponent<AudioSource>().Stop();
        m_playMusicLoop.GetComponent<AudioSource>().Play();
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

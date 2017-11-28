using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class MenuManager : MonoBehaviour
{
    //String to load first level
    public string m_firstLevel = "";

    //Music varibles
    public GameObject m_menuMusicLoop = null;
    public float m_musicFadeIn = 1.0f;
    public float m_musicFadeOut = 1.0f;

    private float m_musicFadeInTimer = 0.0f;

    //Image varibles
    public float m_startFadeTime = 2.0f;
    private float m_startFadeTimer = 0.0f;

    private bool m_startFade = false;

    public float m_menuFadeTime = 2.0f;
    private float m_menuFadeTimer = 0.0f;
    private bool m_menuFade = false;

    //Main menu stuff
    public Image m_startBtnImg;
    public Image m_PlayBtnImg;
    public Image m_ControllerBtnImg;
    public Image m_QuitBtnImg;

    public Image m_logoImg = null; //Splash Screen
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
        //Fading in music
        if (m_musicFadeInTimer < m_musicFadeIn) // Fading start button away 
        {
            m_musicFadeInTimer += Time.deltaTime;
            m_menuMusicLoop.GetComponent<AudioSource>().volume = m_musicFadeInTimer / m_musicFadeIn;
        }

        //Pausing Screen
        if (XCI.GetButtonDown(XboxButton.Start))
        {
            m_startFade = true;
        }

        if(m_startFade && m_startFadeTimer < m_startFadeTime) // Fading start button away 
        {
            m_startFadeTimer += Time.deltaTime;
            float alpha = m_startFadeTimer / m_startFadeTime;

            SetAlpha(1 - alpha, m_startBtnImg);

            if(m_startFadeTimer >= m_startFadeTime)
            {
                m_PlayBtnImg.gameObject.SetActive(true);
                m_QuitBtnImg.gameObject.SetActive(true);

                SetAlpha(0, m_PlayBtnImg);
                SetAlpha(0, m_QuitBtnImg);

                m_menuFade = true;

                StartCoroutine(HighlightButton(m_PlayBtnImg.gameObject)); // Due to unity bug need to set higlighted at end of frame
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

            if (m_startGameTimer < 1.4) //Fade in UI to 70%
            {
                float alpha = m_startGameTimer / 2.0f;
                SetAlpha(alpha, m_fadeImage);
            }
            else
            {
                SetAlpha(0.7f, m_fadeImage);
            }

            if (m_startGameTimer < 2.0f) //Fade in UI 100%
            {
                float alpha = m_startGameTimer / 2.0f;
                SetAlpha(1 - alpha, m_PlayBtnImg);
                SetAlpha(1 - alpha, m_QuitBtnImg);
                SetAlpha(0.7f - alpha, m_logoImg);
                SetAlpha(alpha, m_ControllerBtnImg);
            }
            else
            {
                SetAlpha(0.0f, m_PlayBtnImg);
                SetAlpha(0.0f, m_QuitBtnImg);
                SetAlpha(0.0f, m_logoImg);
                SetAlpha(1.0f, m_ControllerBtnImg);
            }

            //Fading in music
            if (m_startGameTimer > m_startGameTime - m_musicFadeOut) // Fading start button away 
            {
                m_menuMusicLoop.GetComponent<AudioSource>().volume = (m_startGameTime - m_startGameTimer) / m_musicFadeOut;
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
    }

    //--------------------------------------------------------------------------------------
    // Quit application
    //--------------------------------------------------------------------------------------
    public void QuitBtn()
    {
        Application.Quit();
    }

    //--------------------------------------------------------------------------------------
    //  Set image alpha
    //
    // Param:
    //		alpha: alpha to set image to, between 0-1
    //		image: image to change alpha of
    //--------------------------------------------------------------------------------------
    private void SetAlpha(float alpha, Image image)
    {
        Color tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
    }


    //--------------------------------------------------------------------------------------
    //  Set the current highlighted button
    //  Due to unity bug need to set higlighted at end of frame
    //
    // Param:
    //		team: whic team is the bullet on, enemy or player layer
    //--------------------------------------------------------------------------------------
    IEnumerator HighlightButton(GameObject button)
    {
        UnityEngine.EventSystems.EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();

        eventSystem.SetSelectedGameObject(null);

        yield return new WaitForEndOfFrame();
        eventSystem.SetSelectedGameObject(button);
    }
}

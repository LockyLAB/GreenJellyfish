using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class ControlScreenManager : MonoBehaviour
{
    public float m_fadeTime = 1.0f;
    private float m_fadeTimer = 0.0f;

    private bool m_fadeIn = false;
    private bool m_fadeOut = false;


    private float m_fadeInGradiant = 0.0f;

    private Image m_image = null;

    private void Awake()
    {
        m_fadeInGradiant = 1 / m_fadeTime;
        m_image = GetComponentInChildren<Image>();

        SetImageAlpha(0.0f);
    }

    //--------------------------------------------------------------------------------------
    // When enabled fade controls in
    //--------------------------------------------------------------------------------------
    public void OnEnable()
    {
        m_fadeIn = true;
        m_fadeTimer = 0.05f;

        SetImageAlpha(0.0f);
    }

    //--------------------------------------------------------------------------------------
    // Update
    // Return to game scene
    //--------------------------------------------------------------------------------------
    public void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Back) && !m_fadeIn && !m_fadeOut) //User input
        {
            m_fadeOut = true;
        }

        if (m_fadeIn) //Fading in
        {
            StartCoroutine(Clock(0.05f));

            if (m_fadeTimer < m_fadeTime)
            {
                float fadePercent = m_fadeInGradiant * m_fadeTimer;
                SetImageAlpha(fadePercent);
                Time.timeScale = 1.0f - fadePercent;
            }
            else
            {
                m_fadeIn = false;
                SetImageAlpha(1.0f);
                m_fadeTimer = 0.05f;
                Time.timeScale = 0.0f;
            }
        }

        if (m_fadeOut) //Fading out TODO
        {

            StartCoroutine(Clock(0.05f));

            if (m_fadeTimer < m_fadeTime)
            {
                float fadePercent = m_fadeInGradiant * m_fadeTimer;
                SetImageAlpha(1.0f- fadePercent);
                Time.timeScale = fadePercent;
            }
            else
            {
                m_fadeOut = false;
                SetImageAlpha(0.0f);
                m_fadeTimer = 0.05f;
                Time.timeScale = 1.0f;
                gameObject.SetActive(false);
            }
        }
    }


    //--------------------------------------------------------------------------------------
    // Update
    // Return to game scene
    //
    //  param:
    //      alpha - Alpha to set sprite
    //--------------------------------------------------------------------------------------
    private void SetImageAlpha(float alpha)
    {
        Color tempColor = m_image.color;
        tempColor.a = alpha;
        m_image.color = tempColor;
    }

    //--------------------------------------------------------------------------------------
    // Clock not related to delta time
    //
    // Param:
    //		delay: how long effect should follow player for
    //--------------------------------------------------------------------------------------
    IEnumerator Clock(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_fadeTimer += delay;
    }
}

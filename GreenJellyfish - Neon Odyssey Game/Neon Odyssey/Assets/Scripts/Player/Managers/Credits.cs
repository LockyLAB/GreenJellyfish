using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public string m_menu; //Next level


    public GameObject m_creditsLogo = null;
    public GameObject m_creditsScrollOver = null;

    public float m_backgroundFadeIn = 1.0f;
    private float m_backgroundFadeInTimer = 0.0f;

    public float m_scrollSpeed = 1.0f;

    private bool m_creditsEnabled = false;


    // Update is called once per frame
    void Update ()
    {
        if (m_creditsEnabled)
        {
            if (m_backgroundFadeInTimer < m_backgroundFadeIn) //Fade in background and logo
            {
                m_backgroundFadeInTimer += Time.deltaTime;

                //Set alpha
                SetImageAlpha(m_creditsLogo, m_backgroundFadeInTimer / m_backgroundFadeIn * 2);
            }
            else if (m_creditsScrollOver.transform.position.y < Screen.height + (m_creditsScrollOver.GetComponent<Image>().sprite.rect.height/2)) //Scroll text
            {
                Vector3 creditsPos = m_creditsScrollOver.transform.position;
                creditsPos.y += m_scrollSpeed * Time.deltaTime;
                m_creditsScrollOver.transform.position = creditsPos;
            }
            else
            {
                SceneManager.LoadScene(m_menu);
            }
        }
	}

    //--------------------------------------------------------------------------------------
    // Update
    // Return to game scene
    //
    //  param:
    //      imageObject - Game object containg image to change alpha of
    //      alpha - Alpha to set sprite
    //--------------------------------------------------------------------------------------
    private void SetImageAlpha(GameObject imageObject,  float alpha)
    {
        Color tempColor = imageObject.GetComponent<Image>().color;
        tempColor.a = alpha;
        imageObject.GetComponent<Image>().color = tempColor;
    }

    //--------------------------------------------------------------------------------------
    // On trigger enter
    // Case of player load next level
    //
    // Param:
    //		other: object player has collided with
    //--------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_creditsEnabled = true;

            //Disable player input
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_inputOn = false;
        }
    }
}

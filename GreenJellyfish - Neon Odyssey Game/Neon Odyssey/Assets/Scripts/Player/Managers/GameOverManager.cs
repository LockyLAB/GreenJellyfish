﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject m_topButton = null;

    //--------------------------------------------------------------------------------------
    // When game over screen displays, ensure button is initially selected
    //--------------------------------------------------------------------------------------
    public void OnEnable()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        if(m_topButton != null)
            eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(m_topButton);
    }

    //--------------------------------------------------------------------------------------
    // Load main menu
    //--------------------------------------------------------------------------------------
    public void GoToMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    //--------------------------------------------------------------------------------------
    // Quit application
    //--------------------------------------------------------------------------------------
    public void QuitBtn()
    {
        Application.Quit();
    }

    //--------------------------------------------------------------------------------------
    // Reload scene
    //--------------------------------------------------------------------------------------
    public void RetryLevelBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

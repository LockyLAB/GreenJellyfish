using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject m_topButton = null;

    //--------------------------------------------------------------------------------------
    // When game over screen displays, ensure button is initially selected
    //--------------------------------------------------------------------------------------
    public void OnEnable()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        if (m_topButton != null)
            eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(m_topButton);
    }

    //--------------------------------------------------------------------------------------
    // Return to game scene
    //--------------------------------------------------------------------------------------
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    //--------------------------------------------------------------------------------------
    // Quit Application
    //--------------------------------------------------------------------------------------
    public void QuitBtn()
    {
        Application.Quit();
    }

    //--------------------------------------------------------------------------------------
    // Return to menu scene
    //--------------------------------------------------------------------------------------
    public void GoToMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}

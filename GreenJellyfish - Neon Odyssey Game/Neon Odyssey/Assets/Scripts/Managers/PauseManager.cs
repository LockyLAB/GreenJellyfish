using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject m_topButton = null;

    public void OnEnable()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        if (m_topButton != null)
            eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(m_topButton);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void GoToMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}

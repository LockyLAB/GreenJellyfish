using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour {

    public string m_nextLevel; //Next level

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
            SceneManager.LoadScene(m_nextLevel);
        }
    }
}

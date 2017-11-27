using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayshieldTrigger : MonoBehaviour {

    public GameObject boss;
    public GameObject m_bossBar = null;

    public GameObject shield;
    private bool triggered;

    void Start()
    {
        //shield.SetActive(true);
        triggered = false;
    }
    // Update is called once per frame
    void Update () {
        
        if (!triggered)
        {
            if (boss == null) //End arena area on boss death
            {
                shield.SetActive(false);
                triggered = true;
            }
            else //Update Boss UI
            {
                //Scale UI health bar to health
                if (m_bossBar != null)
                {
                    Vector3 healthBarScale = m_bossBar.GetComponent<Image>().rectTransform.localScale;
                    healthBarScale.x = (float)boss.GetComponent<Character>().GetHealth() / (float)boss.GetComponent<Character>().m_healthMax;

                    m_bossBar.GetComponent<Image>().rectTransform.localScale = healthBarScale;
                }
            }
        }
	}
}

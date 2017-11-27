using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayshieldTrigger : MonoBehaviour {

    public GameObject boss;
    public List<GameObject> m_bossBarSections = new List<GameObject>();

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
                //Set UI health bar to health
                if (m_bossBarSections.Count == 3)
                {
                    int bossHealth = boss.GetComponent<Character>().GetHealth();
                    int bossMaxHealth = boss.GetComponent<Character>().m_healthMax;

                    //First health bar
                    if ((bossHealth / 2) % 3 == 2)
                    {
                        m_bossBarSections[2].SetActive(false);
                    }
                    //Second health bar
                    if((bossHealth/2) % 3 == 2)
                    {
                        m_bossBarSections[1].SetActive(false);
                    }
                    //third health bar
                    if ((bossHealth / 2) % 3 == 0)
                    {
                        m_bossBarSections[0].SetActive(false);
                    }
                }
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayshieldTrigger : MonoBehaviour {

    public GameObject boss;
    public List<GameObject> m_bossBarHealthSections = new List<GameObject>();
    public List<GameObject> m_bossBarDeathSections = new List<GameObject>();

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
                if (m_bossBarHealthSections.Count == 3 && m_bossBarDeathSections.Count == 3)
                {
                    int bossHealth = boss.GetComponent<Character>().GetHealth();

                    //First health bar
                    if (bossHealth == 4)
                    {
                        m_bossBarHealthSections[2].SetActive(false);
                        m_bossBarDeathSections[2].SetActive(true);
                    }
                    //Second health bar
                    if(bossHealth == 2)
                    {
                        m_bossBarHealthSections[1].SetActive(false);
                        m_bossBarDeathSections[1].SetActive(true);
                    }
                    //third health bar
                    if (bossHealth == 0)
                    {
                        m_bossBarHealthSections.Clear();
                        m_bossBarDeathSections.Clear();
                    }
                }
            }
        }
	}
}

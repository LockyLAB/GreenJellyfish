using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class AudioManager : MonoBehaviour
{
    public GameObject m_musicIntro = null;
    public GameObject m_musicLoop = null;

    public float m_musicStartDelay = 1.0f;

    public float m_musicFadeIn = 1.0f;
    private float m_musicFadeInTimer = 0.0f;

    private void Start()
    {
        Invoke("StartMusic", m_musicStartDelay);
        m_musicIntro.GetComponent<AudioSource>().volume = 0;
    }

    //--------------------------------------------------------------------------------------
    // Play initial track, at end, play looping track, destroy object
    //--------------------------------------------------------------------------------------
    void Update()
    {
        while(m_musicFadeInTimer < m_musicFadeIn)
        {
            m_musicFadeInTimer += Time.deltaTime;
            m_musicIntro.GetComponent<AudioSource>().volume = m_musicFadeInTimer/ m_musicFadeIn;
        }

        if(!m_musicIntro.GetComponent<AudioSource>().isPlaying)
        {
            m_musicLoop.GetComponent<AudioSource>().Play();
            //Destroy(this);
        }
    }

    //--------------------------------------------------------------------------------------
    // Play initial track after delay
    //--------------------------------------------------------------------------------------
    void StartMusic()
    {
        m_musicIntro.GetComponent<AudioSource>().Play();
    }
}

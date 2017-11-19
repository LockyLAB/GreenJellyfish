using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject m_musicIntro = null;
    public GameObject m_musicLoop = null;

    // Update is called once per frame
    void Update()
    {
        if (!m_musicLoop.GetComponent<AudioSource>().isPlaying)
            if(!m_musicIntro.GetComponent<AudioSource>().isPlaying)
                m_musicLoop.GetComponent<AudioSource>().Play();
    }
}

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

    //--------------------------------------------------------------------------------------
    // Play initial track, at end, play looping track, destroy object
    //--------------------------------------------------------------------------------------
    void Update()
    {
        if(!m_musicIntro.GetComponent<AudioSource>().isPlaying)
        {
            m_musicLoop.GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }
}

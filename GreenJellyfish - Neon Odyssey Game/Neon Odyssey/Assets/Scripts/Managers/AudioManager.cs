using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public float m_maxVolume = 1.0f;

	// Use this for initialization
	void Awake ()
    {
        if (m_maxVolume > 1.0f)
            m_maxVolume = 1.0f;
        if (m_maxVolume < 0.0f)
            m_maxVolume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Loop through all Audio Sources
        foreach (AudioSource source in GetComponents<AudioSource>())
        {
            if (!source.isPlaying)
                Destroy(source); //Remove Audio source game object when finished playing
        }
    }

    public void PlaySound(string sound)
    {
        //Set frequency to be random
        AudioClip soundClip = Resources.Load<AudioClip>(sound);
        AudioSource soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        soundSource.volume = m_maxVolume;
        soundSource.clip = soundClip;

        soundSource.Play();
    }

    public void PlaySoundRndPitch(string sound)
    {
        //Random value
        float rndPitch = Random.Range(0.0f, 1.0f);

        //Set frequency to be random
        AudioClip soundClip = Resources.Load<AudioClip>(sound);
        AudioSource soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        soundSource.volume = m_maxVolume;
        soundSource.pitch = rndPitch;
        soundSource.clip = soundClip;

        soundSource.Play();
    }
}

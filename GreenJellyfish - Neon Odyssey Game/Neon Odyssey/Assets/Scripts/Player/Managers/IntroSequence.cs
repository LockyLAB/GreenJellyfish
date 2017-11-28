using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class IntroSequence : MonoBehaviour
{
    //Players
    public Animator m_player1Animator = null;
    public Animator m_player2Animator = null;

    public Animator m_cameraAnimator = null;

    public GameObject m_portalWaterEffect = null;
    public GameObject m_portalActivationSound = null;

    public float m_portalEffectDelay = 1.0f;
    private bool m_portalEffectActivated = false;

    private bool m_cameraEnabled = false;

    public float m_portalWaterTime = 1.0f;
    private bool m_portalWaterActivated = false;

    public float m_animationTime = 2.0f;
    public float m_sequenceTime = 3.0f;
    private float m_sequenceTimer = 0.0f;

    //--------------------------------------------------------------------------------------
    // Start opening sequence
    //--------------------------------------------------------------------------------------
    private void OnEnable()
    {
        m_player1Animator.enabled = true;
        m_player2Animator.enabled = true;
    }

    //--------------------------------------------------------------------------------------
    // Play different animations at different times
    //--------------------------------------------------------------------------------------
    private void Update()
    {
        m_sequenceTimer += Time.deltaTime;

        if (m_sequenceTimer > m_portalEffectDelay && !m_portalEffectActivated) // Activate portal water
        {
            GameObject activationSound = Instantiate(m_portalActivationSound, Vector3.zero, Quaternion.identity);
            activationSound.GetComponent<AudioSource>().Play();
            Destroy(activationSound, 5.0f);

            m_portalEffectActivated = true;
        }

        if (m_sequenceTimer > m_portalWaterTime && !m_portalWaterActivated) // Activate portal water
        {
            m_portalWaterEffect.SetActive(true);
            m_portalWaterActivated = true;
        }

        if (m_sequenceTimer > m_animationTime && !m_cameraEnabled)//Enable camera and player input at end of timer
        {
            m_cameraEnabled = true;
            GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>().m_dynamicCamera = true;
            Destroy(m_cameraAnimator);
        }

        if(m_sequenceTimer > m_sequenceTime) //Enable player montion at end of opening animation
        {
            //Remove animators
            Destroy(m_player1Animator);
            Destroy(m_player2Animator);

            GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_inputOn = true;
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, ISelectHandler
{
    public Image m_selectedImg;

    public void OnSelect(BaseEventData eventData)
    {
        Color tempColor = m_selectedImg.color;
        tempColor.a = 1.0f;
        m_selectedImg.color = tempColor;
    }

    public void OnDeselect(BaseEventData data)
    {
        Color tempColor = m_selectedImg.color;
        tempColor.a = 0.0f;
        m_selectedImg.color = tempColor;
    }
}

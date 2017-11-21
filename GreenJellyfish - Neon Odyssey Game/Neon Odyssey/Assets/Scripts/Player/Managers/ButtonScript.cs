using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, ISelectHandler
{ 
    public void OnSelect(BaseEventData eventData)
    {
        GetComponent<Image>().rectTransform.localScale = new Vector3(1.2f ,1.2f ,1.2f);
    }

    public void OnDeselect(BaseEventData data)
    {
        GetComponent<Image>().rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
}

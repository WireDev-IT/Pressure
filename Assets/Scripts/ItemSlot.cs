using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool IsCorrect { get; private set; } = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            Text t1 = GetComponentInChildren<Text>();
            if (t1 != null && eventData.pointerDrag.TryGetComponent(out Text t2))
            {
                if (t1.text == t2.text)
                {
                    IsCorrect = true;
                }
                else
                    IsCorrect = false;
            }
        }
    }
}
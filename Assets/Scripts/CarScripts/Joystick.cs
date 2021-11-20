using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Image joyStickBG;
    [SerializeField] Image joyStick;

    Vector2 posInput;

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickBG.rectTransform,eventData.position,eventData.pressEventCamera,out posInput))
        {
            posInput.x = posInput.x / joyStickBG.rectTransform.sizeDelta.x;
            posInput.y = posInput.y / joyStickBG.rectTransform.sizeDelta.y;
            if (posInput.magnitude > 1f)
                posInput = posInput.normalized;

            joyStick.rectTransform.anchoredPosition = new Vector2(posInput.x * (joyStickBG.rectTransform.sizeDelta.x / 2), posInput.y * (joyStickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joyStick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Vertical()
    {
        return posInput.y;
    }

    public float Horizontal()
    {
        return posInput.x;
    }
}

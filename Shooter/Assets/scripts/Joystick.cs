using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joyStick;
    public GameObject joyStickBG;
    public Vector2 joystickVec;
    public Vector2 joystickTouchPosition;
    public Vector2 joystickOrignalPosition;
    public float joystickRadius;



    private void Start()
    {
        joystickOrignalPosition = joyStickBG.transform.position;
        joystickRadius = joyStickBG.GetComponent<RectTransform>().sizeDelta.y / 4;

;    }


    public void PointerDown()
    {
        joyStick.transform.position = Input.mousePosition;
        joyStickBG.transform.position = Input.mousePosition;
        joystickTouchPosition = Input.mousePosition;

    }


    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPosition).normalized;

        float joystickDistance = Vector2.Distance(dragPos, joystickTouchPosition);

        if(joystickDistance < joystickRadius)
        {
            joyStick.transform.position = joystickTouchPosition + joystickVec * joystickDistance;
        }
        else
        {
            joyStick.transform.position = joystickTouchPosition + joystickVec * joystickRadius;
        }

    }


    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joyStick.transform.position = joystickOrignalPosition;
        joyStickBG.transform.position = joystickOrignalPosition;
    }
}

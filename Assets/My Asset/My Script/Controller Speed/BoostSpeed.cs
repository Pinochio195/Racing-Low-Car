using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoostSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameManager.Instance._directionCar.isBosst = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameManager.Instance._directionCar.isBosst = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance._directionCar.isBosst = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance._directionCar.isBosst = false;
    }
}
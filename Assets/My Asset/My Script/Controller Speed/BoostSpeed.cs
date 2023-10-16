using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoostSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

   

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance._directionCar.isBosst = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance._directionCar.isBosst = false;
    }

   
}
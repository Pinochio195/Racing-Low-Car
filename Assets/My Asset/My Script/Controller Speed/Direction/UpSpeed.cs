using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpSpeed : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public float _speedCar;
    public bool isCheckSpeed;

    private void Update()
    {
        SpeedUpCar();
        Debug.Log(_speedCar);
        Debug.Log(Input.GetAxis("Vertical"));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isCheckSpeed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _speedCar = 0;
        isCheckSpeed = false;
    }

    private void SpeedUpCar()
    {
        if (isCheckSpeed)
        {
            _speedCar += 2.6f * Time.deltaTime;
            _speedCar = Mathf.Clamp(_speedCar, 0, 1);
        }
    }
}
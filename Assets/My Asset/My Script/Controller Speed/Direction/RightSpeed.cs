using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float _speedCar;
    public bool isCheckSpeed;

    private void Update()
    {
        SpeedUpCar();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isCheckSpeed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _speedCar = 0;
        isCheckSpeed = false;
        GameManager.Instance._directionCar._speedVertical_Horizontal = _speedCar;
    }

    private void SpeedUpCar()
    {
        if (isCheckSpeed)
        {
            _speedCar += 2.6f * Time.deltaTime;
            _speedCar = Mathf.Clamp(_speedCar, 0, 1);
            GameManager.Instance._directionCar._speedVertical_Horizontal = _speedCar;
        }
    }
}